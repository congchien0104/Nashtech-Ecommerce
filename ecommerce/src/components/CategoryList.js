import React, { useState, useEffect } from "react";
import CategoryService from "../services/category.service";
import { Link } from "react-router-dom";
//import axios from "axios";

const CategoryList = (props) => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    retrieveCategories();
  }, []);
  const retrieveCategories = () => {
    CategoryService.getCategories()
      .then((response) => {
        setCategories(response.data.data);
        //console.log(response.data.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };
  //console.log(categories);
  const openCategory = (id) => {
    console.log(id);

    props.history.push("/categories/" + id);
  };

  return (
    <div className="container">
      <h2>Categories</h2>
      <Link to="/categories/add">Create Category</Link>
      <table className="table mt-5">
        <thead className="thead-dark">
          <tr>
            <th scope="col">STT</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">CreatedDate</th>
            <th scope="col">UpdatedDate</th>
            <th scope="col">Option</th>
          </tr>
        </thead>
        <tbody>
          {categories &&
            categories.map((category, index) => (
              <tr key={index}>
                <th scope="row">{index + 1}</th>
                <td>{category.name}</td>
                <td>{category.description}</td>
                <td>{category.createdDate}</td>
                <td>{category.updatedDate}</td>
                <td>
                  <button
                    type="button"
                    class="btn btn-primary"
                    onClick={() => openCategory(category.id)}
                  >
                    Edit
                  </button>
                  <button type="button" class="btn btn-danger ml-2">
                    Delete
                  </button>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default CategoryList;
