import { MdDeleteForever } from 'react-icons/md';

function Note({ id, title, content, createdAt, handleDeleteNote }) {
    return (
        <div className='note'>
            <div className='note-body'>
                <div className="note-title">
                    <span>{title}</span>
                </div>
                <div className="note-content">
                    <span>{content}</span>
                </div>
            </div>
            <div className='note-footer'>
                <small>{createdAt}</small>
                <MdDeleteForever 
                    onClick={() => handleDeleteNote(id)} 
                    class='delete-icon' 
                    size='1.3em' 
                />
            </div>
        </div>
    );
}

export default Note;