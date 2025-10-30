import { MdDeleteForever, MdOutlineAutorenew, MdOutlineStarRate, MdOutlineStarPurple500 } from 'react-icons/md';
import { useLocation } from 'react-router-dom';

function Note({ id, title, content, createdAt, isFavorite, handleDeleteNote, handleRestoreNote, toggleFavorites }) {
	const location = useLocation();

	const isTrashPage = location.pathname.toLocaleLowerCase().toLowerCase() === '/trash';

	const StarIcon = isFavorite ? MdOutlineStarPurple500 : MdOutlineStarRate;

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
				<div className='note-footer-btn'>
					{ isTrashPage ? (
						<MdOutlineAutorenew 
							onClick={() => handleRestoreNote(id)}
							class='feature-icon'
							size='1.3em'
						/>
					) : (
						<StarIcon
							onClick={() => {
								isFavorite = !isFavorite;
								toggleFavorites(id);
							}}
							class='feature-icon'
							size="1.3em"
						/>
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