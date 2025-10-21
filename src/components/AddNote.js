import { useState } from 'react';

function AddNote({ handleAddNote }) {
	const [noteText, setNoteText] = useState();

	const handleChange = (event) => {
		setNoteText(event.target.value);
	}

	const handleSaveClick = () => {
		handleAddNote(noteText);
	}

	return(
		<div className="note new">
			<textarea 
				rows='8' 
				cols='10' 
				placeholder="Type to add note"
				onChange={handleChange} 
				value={noteText}
			></textarea>
			<div className='note-footer'>
				<small>200 remaining</small>
				<button className='save-note' onClick={handleSaveClick}>Save</button>
			</div>
		</div>
	);
}

export default AddNote;