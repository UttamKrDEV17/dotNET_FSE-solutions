import React from 'react';

function BlogDetails(props) {
  return (
    <div className="component-box">
      <h1>Blog Details</h1>
      {props.blogs.map((blog) => (
        <div key={blog.id}>
          <h3>{blog.title}</h3>
          <p><strong>{blog.author}</strong></p>
          <p>{blog.content}</p>
        </div>
      ))}
    </div>
  );
}

export default BlogDetails;