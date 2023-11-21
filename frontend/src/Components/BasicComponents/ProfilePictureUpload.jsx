// ProfilePictureUpload.jsx
import React, { useState } from 'react';

const ProfilePictureUpload = ({ onProfilePictureChange }) => {
  const [profilePicture, setProfilePicture] = useState(null);
  const [profilePictureArrayBuffer, setProfilePictureArrayBuffer] = useState([])

  const handleFileChange = (e) => {
    const file = e.target.files[0];

    if (file) {
      const arrayBufferReader = new FileReader();
      arrayBufferReader.onloadend = () => {
        setProfilePictureArrayBuffer(arrayBufferReader.result);
        onProfilePictureChange(arrayBufferReader.result);
      };
      arrayBufferReader.readAsArrayBuffer(file);

      const binaryStringReader = new FileReader();
      binaryStringReader.onloadend = () => {
        setProfilePicture(binaryStringReader.result);
      };
      binaryStringReader.readAsDataURL(file);
    }
  };

  const handleCircleClick = () => {
    document.getElementById('fileInput').click();
  };

  return (
    <div>
      <div
        style={{
          margin: '10px auto auto auto',
          width: '150px',
          height: '150px',
          borderRadius: '50%',
          backgroundColor: '#ccc',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          cursor: 'pointer',
        }}
        onClick={handleCircleClick}
      >
        {profilePicture ? (
          <img
            src={profilePicture}
            alt="Profile"
            style={{ width: '100%', height: '100%', borderRadius: '50%' }}
          />
        ) : (
          <span>Click to upload</span>
        )}
      </div>
      <input
        id="fileInput"
        type="file"
        accept="image/*"
        style={{ display: 'none' }}
        onChange={handleFileChange}
      />
    </div>
  );
};

export default ProfilePictureUpload;
