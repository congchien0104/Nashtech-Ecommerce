import React, { useState, useEffect } from "react";
import CustomerService from "../services/customer.service";
//import { Link } from "react-router-dom";
//import axios from "axios";

const CustomerList = () => {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    retrieveCustomers();
  }, []);
  const retrieveCustomers = () => {
    CustomerService.getCustomers()
      .then((response) => {
        setCustomers(response.data.data);
        //console.log(response.data.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };
  //console.log(customers);

  return (
    <div className="container">
      <h2>View Customers</h2>
      <p>
        If you want the borders to collapse into one border, add the CSS
        border-collapse property.
      </p>

      <table className="table">
        <thead className="thead-dark">
          <tr>
            <th scope="col">STT</th>
            <th scope="col">FirstName</th>
            <th scope="col">LastName</th>
            <th scope="col">Email</th>
          </tr>
        </thead>
        <tbody>
          {customers &&
            customers.map((customer, index) => (
              <tr key={index}>
                <th scope="row">{index + 1}</th>
                <td>{customer.firstName}</td>
                <td>{customer.lastName}</td>
                <td>{customer.email}</td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default CustomerList;
