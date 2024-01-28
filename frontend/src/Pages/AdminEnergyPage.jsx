import React, { useEffect, useState } from "react";
import {
  getProperties,
  getPropertiesByUserId,
} from "../Components/Services/PropertiesService";
import PropertyCard from "../Components/BasicComponents/PropertyCard";
import AddButton from "../Components/BasicComponents/AddButton";
import BasicPagination from "../Components/BasicComponents/BasicPagination";
import InfoDialog from "../Components/BasicComponents/InfoDialog"; // Import the InfoDialog
import PropertyStepper from "../Components/BasicComponents/PropertyStepper";
import { useNavigate } from "react-router-dom";
import "./UserPropertiesPage.css";
import LoadingComponent from "../Components/BasicComponents/LoadingComponent";
import axios from "axios";
import { API_BASE_URL } from "../App";

const AdminEnergyPage = ({ user }) => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [properties, setProperties] = useState([]);
  const [pagination, setPagination] = useState({ pageNumber: 1, pageSize: 4 });
  const [totalItems, setTotalItems] = useState(0);
  const [stepperOpen, setStepperOpen] = useState(false);
  const navigate = useNavigate();

  const ClickedProperty = (id) => {
    navigate(id);
  };
  const NotAccepted = (id) => {
    console.log(id + " Not Accepted");
  };

  const [infoDialog, setInfoDialog] = useState({
    open: false,
    title: "",
    content: "",
  });

  const fetchProperties = () => {
    axios
      .get(`${API_BASE_URL}/properties`, { params: pagination })

      .then((response) => {
        setProperties(response.data.items);
        setTotalItems(response.data.totalItems)
        setLoading(false);
        
      })
      .catch((error) => {
        console.error("Error:", error);
      });

  };

  useEffect(() => {
    setLoading(true);
    fetchProperties();
  }, [pagination.pageNumber, pagination.pageSize]);

  const handlePageChange = (newPage) => {
    setPagination({
      ...pagination,
      pageNumber: newPage,
    });
  };

  const handleAddProperty = () => {
    setStepperOpen(true);
  };

  const handleCloseStepper = (creation) => {
    if (creation === 1 && totalItems !== pagination.pageSize) {
      fetchProperties();

      setInfoDialog({
        open: true,
        title: "Property Created",
        content: "The property has been successfully created.",
      });
    }
    setStepperOpen(false);
  };

  if (loading) {
    return <LoadingComponent />;
  }

  return (
    <div className="user-properties-container">
      <BasicPagination
        currentPage={pagination.pageNumber}
        pageSize={pagination.pageSize}
        totalItems={totalItems}
        onPageChange={handlePageChange}
      />
      <div className="property-list-container">
        <div className="property-list">
          {properties.map((property) => (
            <PropertyCard
              key={property.id}
              property={property}
              callback={property.status == 1 ? ClickedProperty : NotAccepted}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default AdminEnergyPage;
