import Note from './Note';
import AddNote from './AddNote';

function NotesList({ notes, handleAddNote, handleDeleteNote }) {
	return (
		<div className='notes-list'>
			{notes.map((note) => (
				<Note 
					id={note.id} 
					title={note.title}
					content={note.content} 
					createdAt={note.createdAt} 
					handleDeleteNote={handleDeleteNote}
				/>
			))}
			<AddNote handleAddNote={handleAddNote}/>
		</div>
	);
}

export default NotesList;