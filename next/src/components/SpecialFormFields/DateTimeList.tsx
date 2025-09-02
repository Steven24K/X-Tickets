'use client';
import React, { useRef, useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlus, faMinus } from '@fortawesome/free-solid-svg-icons';


interface DateTimeListProps {
    name: string
}

const DateTimeList: React.FC<DateTimeListProps> = (props) => {
    const { name } = props
    const [fields, setFields] = useState<number[]>([Date.now()]);
    const nextId = useRef(Date.now());

    const addField = () => {
        nextId.current += 1;
        setFields((prev) => [...prev, nextId.current]);
    };

    const removeField = (id: number) => {
        if (fields.length === 1) return;
        setFields((prev) => prev.filter((fid) => fid !== id));
    };

    return (
        <div className="space-y-4">
            {fields.map((id, idx) => (
                <div key={id} className="flex items-center space-x-2">
                    <input
                        type="datetime-local"
                        className="border rounded px-2 py-1 focus:outline-none focus:ring-2 focus:ring-blue-400"
                        name={`${name}[${id}]`}
                        defaultValue=""
                    />
                    <button
                        type="button"
                        onClick={() => addField()}
                        className="text-green-600 hover:text-green-800 p-2"
                        aria-label="Add date/time"
                    >
                        <FontAwesomeIcon icon={faPlus} />
                    </button>
                    <button
                        type="button"
                        onClick={() => removeField(id)}
                        className={`text-red-600 hover:text-red-800 p-2 ${fields.length === 1 ? 'opacity-50 cursor-not-allowed' : ''}`}
                        aria-label="Remove date/time"
                        disabled={fields.length === 1}
                    >
                        <FontAwesomeIcon icon={faMinus} />
                    </button>
                </div>
            ))}
        </div>
    );
};

export default DateTimeList;