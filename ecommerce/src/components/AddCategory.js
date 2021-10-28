import React, { useState } from "react";
import CategoryService from "../services/category.service";

const AddCategory = () => {
  const initialCategoryState = {
    id: null,
    name: "",
    description: "",
  };
  const [category, setCategory] = useState(initialCategoryState);
  const [submitted, setSubmitted] = useState(false);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setCategory({ ...category, [name]: value });
    //console.log(category);
  };

  const saveCategory = () => {
    var data = {
      name: category.name,
      description: category.description,
    };

    CategoryService.createCategory(data)
      .then((response) => {
        setCategory({
          id: response.data.id,
          name: response.data.name,
          description: response.data.description,
        });
        setSubmitted(true);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const newTutorial = () => {
    setCategory(initialCategoryState);
    setSubmitted(false);
  };

  return (
    <div class="container">
      <div class="row">
        <div class="col">
          <div className="submit-form">
            {submitted ? (
              <div>
                <h4>You submitted successfully!</h4>
                <button className="btn btn-success" onClick={newTutorial}>
                  Add
                </button>
              </div>
            ) : (
              <div>
                <div className="form-group">
                  <label htmlFor="name">Name</label>
                  <input
                    type="text"
                    className="form-control"
                    id="name"
                    required
                    value={category.name}
                    onChange={handleInputChange}
                    name="name"
                  />
                </div>

                <div className="form-group">
                  <label htmlFor="description">Description</label>
                  <input
                    type="text"
                    className="form-control"
                    id="description"
                    required
                    value={category.description}
                    onChange={handleInputChange}
                    name="description"
                  />
                </div>

                <button onClick={saveCategory} className="btn btn-success">
                  Create
                </button>
              </div>
            )}
          </div>
        </div>
        <div class="col"></div>
      </div>
    </div>
  );
};

export default AddCategory;
