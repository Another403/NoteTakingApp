import { MdDeleteForever, MdOutlineAutorenew } from 'react-icons/md';
import { useLocation } from 'react-router-dom';

function Note({ id, title, content, createdAt, isFavorite, handleDeleteNote, handleRestoreNote, toggleFavorites }) {
	const location = useLocation();

	const isTrashPage = location.pathname.toLocaleLowerCase().toLowerCase() === '/trash';

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
				<div>
					{ isTrashPage ? (
						<MdOutlineAutorenew 
							onClick={() => handleRestoreNote(id)}
							class='feature-icon'
							size='1.3em'
						/>
					) : (
						<button class='save' onClick={() => {
							toggleFavorites(id);
							isFavorite = !isFavorite;
						}}>{isFavorite ? "★" : "☆"}</button>
					)}
					<MdDeleteForever 
						onClick={() => handleDeleteNote(id)} 
						class='feature-icon' 
						size='1.3em' 
					/>
				</div>
			</div>
		</div>
	);
}

export default Note;