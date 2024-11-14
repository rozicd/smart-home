import React from "react";
import "./basic-items.css";

const HeaderComponent = ({ name }) => {
    return (
        <div className="header">
            <p>{name}</p>
        </div>
    );
};

export default HeaderComponent;