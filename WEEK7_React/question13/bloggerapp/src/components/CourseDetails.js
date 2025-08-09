import React from 'react';

function CourseDetails(props) {
  const courseList = props.courses.map((course) => (
    <div key={course.id}>
      <h3>{course.name}</h3>
      <p>{course.date}</p>
    </div>
  ));

  return (
    <div className="component-box">
      <h1>Course Details</h1>
      {courseList}
    </div>
  );
}

export default CourseDetails;