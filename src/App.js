import logo from './logo.svg';
import './App.css';
import NotesList from './components/NotesList';

import { useState } from 'react';
import { nanoid } from 'nanoid';

function App() {
	const [notes, setNotes] = useState([
		{
			id: nanoid(),
			text: 'Hello, world!',
			date: '21/10/2025'
		},
		{
			id: nanoid(),
			text: 'Hello, world! (1)',
			date: '21/10/2025'
		},
		{
			id: nanoid(),
			text: 'Hello, world! (2)',
			date: '21/10/2025'
		},
	]);

	const addNote = (text) => {
		const date = new Date();
		const newNote = {
			id: nanoid(),
			text: text,
			date: date.toLocaleDateString(),
		};

		const newNotes = [...notes, newNote];
		setNotes(newNotes);
	}

	return (
		<div className="container">
			<NotesList notes={notes} handleAddNote={addNote}/>
		</div>
	);
}

export default App;
