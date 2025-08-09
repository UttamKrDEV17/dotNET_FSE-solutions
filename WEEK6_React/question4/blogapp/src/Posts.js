import React from 'react';

class Posts extends React.Component {
  constructor(props) {
    super(props);
    // Initialize the state to hold the posts and a loading flag
    this.state = {
      posts: [],
      isLoading: true,
      error: null,
    };
  }

  // Method to fetch the posts from the API
  loadPosts = async () => {
    try {
      const response = await fetch('https://jsonplaceholder.typicode.com/posts');
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();
      // Update the state with the fetched data and set loading to false
      this.setState({
        posts: data,
        isLoading: false,
      });
    } catch (error) {
      // If there's an error, store it in the state
      this.setState({
        error,
        isLoading: false,
      });
    }
  };

  componentDidMount() {
    // Call the loadPosts method when the component first mounts
    this.loadPosts();
  }

  render() {
    // Destructure state for easier access
    const { posts, isLoading, error } = this.state;

    // Conditional rendering based on the state
    if (isLoading) {
      return <div>Loading posts...</div>;
    }

    if (error) {
      return <div>Error: {error.message}</div>;
    }

    // If data is loaded successfully, map through the posts and display them
    return (
      <div>
        <h1>Posts</h1>
        <ul>
          {posts.map(post => (
            <li key={post.id}>
              <h2>{post.title}</h2>
              <p>{post.body}</p>
            </li>
          ))}
        </ul>
      </div>
    );
  }

  // You can use componentDidCatch for error boundaries, but it's not
  // typically used for handling fetch errors within the component itself.
  componentDidCatch(error, info) {
    console.error("Component caught an error:", error, info);
  }
}

export default Posts;