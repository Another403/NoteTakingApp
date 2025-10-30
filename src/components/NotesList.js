import Note from './Note';
import AddNote from './AddNote';

function NotesList({ notes, handleAddNote, handleDeleteNote, handleRestoreNote, toggleFavorites }) {
	return (
		<div className='notes-list'>
			{notes.map((note) => (
				<Note 
					id={note.id} 
					title={note.title}
					content={note.content} 
					createdAt={note.createdAt}
					isFavorite={note.isFavorite}
					handleDeleteNote={handleDeleteNote}
					handleRestoreNote={handleRestoreNote}
					toggleFavorites={toggleFavorites}
				/>
			))}
			<AddNote handleAddNote={handleAddNote}/>
		</div>
	);
}

export default NotesList;