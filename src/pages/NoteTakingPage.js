import '../App.css';
import NotesList from '../components/NotesList';
import Search from '../components/Search';
import Header from '../components/Header';
import axios from 'axios';
import {api} from '../api';

import React, { useState, useEffect } from 'react';
import { nanoid } from 'nanoid';

function NoteTakingPage() {
	const [notes, setNotes] = useState([]);

	const [searchText, setSearchText] = useState('');
	const [darkMode, setDarkMode] = useState(false);

	const addNote = (content, title) => {
		const date = new Date();
		const newNote = {
			id: nanoid(),
			title: title,
			content: content,
			createdAt: date.toLocaleDateString()
		};

		const newNotes = [...notes, newNote];
		setNotes(newNotes);
	}

	useEffect(() => {
		api.get('/notes', {
			headers: {
				Authorization: `Bearer ${localStorage.getItem('token')}`
			}
		})
		.then(res => setNotes(res.data))
		.catch(err => console.error(err));
	}, []);

	const deleteNote = (id) => {
		const newNotes = notes.filter((note) => note.id !== id);
		setNotes(newNotes);
	}

	return (
		<div className={`${darkMode && 'dark-mode'}`}>
			<div className="container">
				<Header handleToggleDarkMode={setDarkMode}/>
				<Search handleSearchNote={setSearchText}/>
				<NotesList 
					notes={notes.filter((note) =>
						note.content.toLowerCase().includes(searchText.toLowerCase())
					)} 
					handleAddNote={addNote}
					handleDeleteNote={deleteNote}
				/>
			</div>
		</div>
	);
}

export default NoteTakingPage;