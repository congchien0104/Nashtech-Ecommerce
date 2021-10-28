import React, { useState, useEffect } from "react";
import CategoryService from "../services/category.service";

const Category = (props) => {
  const initialCategoryState = {
    id: null,
    name: "",
    description: "",
  };
  const [currentCategory, setCurrentCategory] = useState(initialCategoryState);
  const [message, setMessage] = useState("");

  const getCategory = (id) => {
    CategoryService.getCategory(id)
      .then((response) => {
        setCurrentCategory(response.data);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  useEffect(() => {
    getCategory(props.match.params.id);
    console.log(props.match.params.id);
  }, [props.match.params.id]);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setCurrentCategory({ ...currentCategory, [name]: value });
  };

  const updateCategory = () => {
    console.log(currentCategory.id);
    CategoryService.updateCategory(currentCategory.id, currentCategory)
      .then((response) => {
        console.log(response.data);
        setMessage("The category was updated successfully!");
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const deleteCategory = () => {
    console.log(currentCategory.id);
    CategoryService.removeCategory(currentCategory.id)
      .then((response) => {
        console.log(response.data);
        props.history.push("/categories");
      })
      .catch((e) => {
        console.log(e);
      });
  };

  return (
    <div class="container">
      <div class="row">
        <div class="col">
          <div>
            {currentCategory ? (
              <div className="edit-form">
                <h4>Category</h4>
                <form>
                  <div className="form-group">
                    <label htmlFor="name">Name</label>
                    <input
                      type="text"
                      className="form-control"
                      id="name"
                      name="name"
                      value={currentCategory.name}
                      onChange={handleInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="description">Description</label>
                    <input
                      type="text"
                      className="form-control"
                      id="description"
                      name="description"
                      value={currentCategory.description}
                      onChange={handleInputChange}
                    />
                  </div>
                </form>

                <button
                  className="btn btn-danger mr-2"
                  onClick={deleteCategory}
                >
                  Delete
                </button>

                <button
                  type="submit"
                  className="btn btn-primary"
                  onClick={updateCategory}
                >
                  Update
                </button>
                <p>{message}</p>
              </div>
            ) : (
              <div>
                <br />
                <p>Please click on a Tutorial...</p>
              </div>
            )}
          </div>
        </div>
        <div class="col"></div>
      </div>
    </div>
  );
};

export default Category;
