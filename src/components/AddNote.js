import { useState } from 'react';

function AddNote({ handleAddNote }) {
	const [noteText, setNoteText] = useState('');
	const [noteTitle, setNoteTitle] = useState('');
	const characterLimit = 200, titleLimit = 25;

	const handleChange = (event) => {
		if (characterLimit - event.target.value.length >= 0) {
			setNoteText(event.target.value);
		}
	}

	const handleTitleChange = (event) => {
		if (titleLimit - event.target.value.length >= 0) {
			setNoteTitle(event.target.value);
		}
	}

	const handleSaveClick = () => {
		if (noteText.trim().length > 0) {
			handleAddNote(noteText, noteTitle);
			setNoteText('');
			setNoteTitle('');
		}
	}

	return (
		<div className="note new">
			<textarea
				className='note-title'
				rows='1'
				cols='10'
				placeholder='Title'
				onChange={handleTitleChange}
				value={noteTitle}
			></textarea>
			<textarea 
				className='note-content'
				rows='8' 
				cols='10' 
				placeholder="Type to add note"
				onChange={handleChange} 
				value={noteText}
			></textarea>
			<div className='note-footer'>
				<small>{characterLimit - noteText.length} remaining</small>
				<button className='save' onClick={handleSaveClick}>Save</button>
			</div>
		</div>
	);
}

export default AddNote;