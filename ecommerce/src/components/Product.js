import React, { useState, useEffect } from "react";
import CategoryService from "../services/category.service";
import ProductService from "../services/product.service";

const Product = (props) => {
  const initialProductState = {
    id: null,
    name: "",
    description: "",
    price: "",
    promationPrice: "",
    quantity: null,
    image: "",
    categoryID: "",
  };

  const [categories, setCategories] = useState([]);
  const [currentProduct, setCurrentProduct] = useState(initialProductState);
  const [message, setMessage] = useState("");
  const [file, setFile] = useState();
  const [fileName, setFileName] = useState();

  const getProduct = (id) => {
    ProductService.getProduct(id)
      .then((response) => {
        setCurrentProduct(response.data);
        //console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  useEffect(() => {
    getProduct(props.match.params.id);
    //retrieveCategories();
    //console.log(categories);
    console.log(props.match.params.id);
  }, [props.match.params.id]);

  useEffect(() => {
    retrieveCategories();
  }, []);
  const retrieveCategories = () => {
    CategoryService.getCategories()
      .then((response) => {
        setCategories(response.data);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setCurrentProduct({ ...currentProduct, [name]: value });
  };
  const handleImageChange = (e) => {
    //console.log(e.target.files[0]);
    setFile(e.target.files[0]);
    setFileName(e.target.files[0].name);
  };

  const submitForm = (e) => {
    e.preventDefault();
    alert("You have submitted the form.");
    console.log("Edit");
    console.log(currentProduct);
    var formData = new FormData();
    formData.append("formfile", file);
    formData.append("filename", fileName);
    formData.append("id", currentProduct.id);
    formData.append("name", currentProduct.name);
    formData.append("description", currentProduct.description);
    formData.append("price", currentProduct.price);
    formData.append("promationPrice", currentProduct.promationPrice);
    formData.append("quantity", currentProduct.quantity);
    formData.append("categoryID", currentProduct.categoryID);
    // console.log(formData);
    // var data = {
    //   id: currentProduct.id,
    //   name: currentProduct.name,
    //   description: currentProduct.description,
    //   price: currentProduct.price,
    //   promationprice: currentProduct.promationprice,
    //   quantity: currentProduct.quantity,
    //   image: currentProduct.image,
    //   categoryid: currentProduct.categoryid,
    // };
    console.log(formData.id);
    ProductService.updateProduct(currentProduct.id, formData)
      .then((response) => {
        //console.log(response.data);
        props.history.push("/products");
        setMessage("The category was updated successfully!");
      })
      .catch((e) => {
        console.log(e);
      });
  };

  return (
    <div className="container">
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
              value={currentProduct.name}
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
              value={currentProduct.quantity}
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
            value={currentProduct.description}
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
              value={currentProduct.price}
            />
          </div>
          <div class="form-group col-md-6">
            <label htmlFor="promationPrice">PromationPrice</label>
            <input
              type="text"
              class="form-control"
              id="promationPrice"
              placeholder="PromationPrice"
              onChange={handleInputChange}
              name="promationPrice"
              value={currentProduct.promationPrice}
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
            <label htmlFor="categoryID">Category</label>
            <select
              id="categoryID"
              class="form-control"
              name="categoryID"
              onChange={handleInputChange}
              value={currentProduct.categoryID}
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
          Update Product
        </button>
      </form>
    </div>
  );
};

export default Product;
