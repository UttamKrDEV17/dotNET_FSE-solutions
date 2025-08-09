import React from 'react';
import './App.css';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';

function App() {
  const books = [
    { id: 101, bname: 'Master React', price: 670 },
    { id: 102, bname: 'Deep Dive into Angular 11', price: 800 },
    { id: 103, bname: 'Mongo Essentials', price: 450 },
  ];

  const blogs = [
    { id: 201, title: 'React Learning', author: 'Stephen Biz', content: 'Welcome to learning React!' },
    { id: 202, title: 'Installation', author: 'Schwzdenier', content: 'You can install React from npm.' },
  ];

  const courses = [
    { id: 301, name: 'Angular', date: '4/5/2021' },
    { id: 302, name: 'React', date: '6/3/2020' },
  ];

  return (
    <div className="App">
      <div className="container">
        <BookDetails books={books} />
        <BlogDetails blogs={blogs} />
        <CourseDetails courses={courses} />
      </div>
    </div>
  );
}

export default App;