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

	const fetchNotes = async () => {
		const res = await api.get('/notes');
		setNotes(res.data);
	}

	const addNote = async (content, title) => {
		const newNote = { id: nanoid(), title, content };
		setNotes(prev => [...prev, newNote]);
		try {
			await api.post('/notes', {
				title: title,
				content: content
			});
			await fetchNotes();
		} catch (err) {
			console.error(err);
			fetchNotes();
		}
	}

	useEffect(() => {
		api.get('/notes')
		.then(res => setNotes(res.data))
		.catch(err => console.error(err));
	}, []);

	const deleteNote = async (id) => {
		setNotes(notes.filter(note => note.id !== id));
		try {
			await api.delete(`/notes/${id}`);
			await fetchNotes();
		} catch (err) {
			console.error(err);
			fetchNotes();
		}
	}

	const toggleFavorites = async (id) => {
		try {
			await api.put(`/notes/favorite/${id}`);
			await fetchNotes();
		} catch (err) {
			console.error(err);
			fetchNotes();
		}
	}

	const handleLogout = async () => {
		try {
			await api.post("/logout");
		} finally {
			localStorage.clear();
			window.location.href = "/";
		}
	}

	return (
		<div className={`${darkMode && 'dark-mode'}`}>
			<div className="container">
				<Header
					pageTitle="Notes" 
					handleToggleDarkMode={setDarkMode}
					handleLogout={handleLogout}/>
				<Search handleSearchNote={setSearchText}/>
				<NotesList 
					notes={notes.filter((note) =>
						note.content.toLowerCase().includes(searchText.toLowerCase())
						&& note.isTrash === false
					)} 
					handleAddNote={addNote}
					handleDeleteNote={deleteNote}
					toggleFavorites={toggleFavorites}
				/>
			</div>
		</div>
	);
}

export default NoteTakingPage;