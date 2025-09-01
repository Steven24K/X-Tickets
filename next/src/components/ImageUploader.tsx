"use client"
import { None, Option, Some } from "@/types/Func"
import Image from "next/image"
import { useEffect, useState } from "react"

interface ImageUploaderProps {
    userId: string
    isOwner: boolean
    imageUrl?: string
    defaultImage: string
    height: number
    width: number
    imgClassName?: string
    editClassName?: string
    entity: ImageEntity
}

type ImageEntity = 'ProfilePicture' | 'Banner' | 'EventImage';

interface ImageUploaderState {
    imageContent: Option<string>
    uploadStatus: 'not-uploaded' | 'uploading' | 'uploaded'
}

export const ImageUploader = (props: ImageUploaderProps) => {
    const { userId, isOwner, imageUrl, defaultImage, height, width, imgClassName, editClassName, entity } = props;
    const [state, setState] = useState<ImageUploaderState>({ imageContent: None(), uploadStatus: 'not-uploaded' })

    const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = (loadEvent) => {
                setState({
                    imageContent: Some(loadEvent.target?.result as string),
                    uploadStatus: 'uploading'
                });
            };
            reader.readAsDataURL(file);
        }
    };

    const attachImageTo = (entity: ImageEntity) => (image_id: number): Promise<Response> => {
        if (entity === 'ProfilePicture' || entity === 'Banner')
            return fetch('/api/updateUser', {
                method: 'POST',
                body: JSON.stringify({ id: userId, data: { [entity]: image_id } }),
                headers: { 'Content-Type': 'application/json' }
            })
        return Promise.reject('Unknown entity')
    }

    useEffect(() => {
        if (state.uploadStatus === 'uploading' && state.imageContent.kind == 'l') {
            fetch(`/api/uploadFile`, {
                method: 'POST',
                body: JSON.stringify({ file: state.imageContent.v }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(res => res.json())
                .then(json => json[0].id)
                .then(attachImageTo(entity))
                .then(response => {
                    if (response.ok) setState(s => ({ ...s, uploadStatus: 'uploaded' }))
                    return Promise.reject('Upload failed')
                })
                .catch(() => setState(s => ({ ...s, uploadStatus: 'not-uploaded' })));
        }
    }, [state.uploadStatus])

    return <>
        <Image
            src={state.imageContent.visit(url => url, () => imageUrl ? imageUrl : defaultImage)}
            alt="Organizer"
            className={imgClassName}
            height={height}
            width={width}
        />
        {state.uploadStatus === 'uploading' && (
            <div className="opacity-40 absolute inset-0 flex items-center justify-center bg-gray-500 rounded-full z-20">
                <div className="w-10 h-10 border-4 border-white border-t-transparent rounded-full animate-spin"></div>
            </div>
        )}
        {isOwner && (
            <form>
                <label className={editClassName}>
                    Edit Photo
                    <input onChange={handleImageChange} type="file" accept="image/*" className="hidden" />
                </label>
            </form>
        )}
    </>
}