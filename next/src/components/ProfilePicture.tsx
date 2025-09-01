"use client"
import { None, Option, Some } from "@/types/Func"
import Image from "next/image"
import { useEffect, useState } from "react"

interface ProfilePictureProps {
    userId: string
    isOwner: boolean
    imageUrl?: string
}

interface ProfilePictureState {
    imageContent: Option<string>
    uploadStatus: 'not-uploaded' | 'uploading' | 'uploaded'
}

export const ProfilePicture = (props: ProfilePictureProps) => {
    const { isOwner, imageUrl, userId } = props;

    const [state, setState] = useState<ProfilePictureState>({ imageContent: None(), uploadStatus: 'not-uploaded' })

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
                .then(image_id => fetch('/api/updateUser', {
                    method: 'POST',
                    body: JSON.stringify({ id: userId, imageId: image_id }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }))
                .then(response => {
                    if (response.ok) setState(s => ({ ...s, uploadStatus: 'uploaded' }))
                    return Promise.reject('Upload failed')
                })
                .catch(() => setState(s => ({ ...s, uploadStatus: 'not-uploaded' })));
        }
    }, [state.uploadStatus])

    return <div className="relative">
        <Image
            src={state.imageContent.visit(url => url, () => imageUrl ? imageUrl : "/profile.avif")}
            alt="Organizer"
            className="w-32 h-32 rounded-full border-4 border-white object-cover shadow-lg"
            height={128}
            width={128}
        />
        {state.uploadStatus === 'uploading' && (
            <div className="opacity-40 absolute inset-0 flex items-center justify-center bg-gray-500 rounded-full z-20">
                <div className="w-10 h-10 border-4 border-white border-t-transparent rounded-full animate-spin"></div>
            </div>
        )}
        {isOwner && (
            <form>
                <label className="absolute bottom-2 left-4 bg-black bg-opacity-60 text-white px-2 py-1 rounded cursor-pointer text-xs z-10">
                    Edit Photo
                    <input onChange={handleImageChange} type="file" accept="image/*" className="hidden" />
                </label>
            </form>
        )}
    </div>
}