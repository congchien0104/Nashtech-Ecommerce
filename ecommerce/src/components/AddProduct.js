import React, { useEffect, useState } from "react";
import CategoryService from "../services/category.service";
import ProductService from "../services/product.service";

const AddProduct = (props) => {
  const initialProductState = {
    id: null,
    name: "",
    description: "",
    price: "",
    promationprice: "",
    quantity: null,
    image: "",
    categoryid: "",
  };

  const [categories, setCategories] = useState([]);
  const [product, setProduct] = useState(initialProductState);
  const [submitted, setSubmitted] = useState(false);
  const [file, setFile] = useState();
  const [fileName, setFileName] = useState();

  //console.log(categories);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setProduct({ ...product, [name]: value });
    console.log(product);
  };
  const handleImageChange = (e) => {
    console.log(e.target.files[0]);
    setFile(e.target.files[0]);
    setFileName(e.target.files[0].name);
  };

  useEffect(() => {
    CategoryService.getCategories()
      .then((response) => {
        setCategories(response.data);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  }, []);

  const submitForm = (e) => {
    e.preventDefault();
    //alert("You have submitted the form.");
    var formData = new FormData();
    formData.append("formfile", file);
    formData.append("filename", fileName);
    formData.append("name", product.name);
    formData.append("description", product.description);
    formData.append("price", product.price);
    formData.append("promationprice", product.promationprice);
    formData.append("quantity", product.quantity);
    formData.append("categoryid", product.categoryid);
    // var data = {
    //   name: product.name,
    //   description: product.description,
    //   price: product.price,
    //   promationprice: product.promationprice,
    //   quantity: product.quantity,
    //   image: product.image,
    //   categoryid: product.categoryid,
    // };

    ProductService.createProduct(formData)
      .then((response) => {
        // setProduct({
        //   id: response.data.id,
        //   name: response.data.name,
        //   description: response.data.description,
        //   price: response.data.price,
        //   promationprice: response.data.promationprice,
        //   quantity: response.data.quantity,
        //   image: response.data.image,
        //   categoryid: response.data.categoryid,
        // });
        setSubmitted(true);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const newProduct = () => {
    setProduct(initialProductState);
    setSubmitted(false);
  };

  return (
    <div className="container">
      {submitted ? (
        <div>
          <h4>You submitted successfully!</h4>
          <button className="btn btn-success" onClick={newProduct}>
            Add
          </button>
        </div>
      ) : (
        <form onSubmit={submitForm}>
          <div class="form-row">
            <div class="form-group col-md-6">
              <label htmlFor="name">Name</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Name"
                onChange={handleInputChange}
                name="name"
              />
            </div>
            <div class="form-group col-md-6">
              <label htmlFor="quantity">Quantity</label>
              <input
                type="number"
                class="form-control"
                id="quantity"
                placeholder="Quantity"
                onChange={handleInputChange}
                name="quantity"
              />
            </div>
          </div>
          <div class="form-group">
            <label htmlFor="description">Description</label>
            <input
              type="text"
              class="form-control"
              id="description"
              placeholder="Description"
              onChange={handleInputChange}
              name="description"
            />
          </div>
          <div class="form-row">
            <div class="form-group col-md-6">
              <label htmlFor="price">Price</label>
              <input
                type="text"
                class="form-control"
                id="price"
                placeholder="Price"
                onChange={handleInputChange}
                name="price"
              />
            </div>
            <div class="form-group col-md-6">
              <label htmlFor="promationprice">PromationPrice</label>
              <input
                type="text"
                class="form-control"
                id="promationprice"
                placeholder="PromationPrice"
                onChange={handleInputChange}
                name="promationprice"
              />
            </div>
          </div>
          <div class="form-row">
            <div class="form-group col-md-6">
              <label htmlFor="image">Image</label>
              <input
                type="file"
                class="form-control"
                id="image"
                name="image"
                onChange={handleImageChange}
              />
            </div>
            <div class="form-group col-md-6">
              <label htmlFor="categoryid">Category</label>
              <select
                id="categoryid"
                class="form-control"
                name="categoryid"
                onChange={handleInputChange}
              >
                {categories.map((category, index) => (
                  <option key={index} value={category.id}>
                    {category.name}
                  </option>
                ))}
              </select>
            </div>
          </div>

          <button type="submit" class="btn btn-primary">
            Create Product
          </button>
        </form>
      )}
    </div>
  );
};

export default AddProduct;
