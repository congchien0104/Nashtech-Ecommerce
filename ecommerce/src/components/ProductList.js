import React, { useState, useEffect } from "react";
import ProductService from "../services/product.service";
import { Link } from "react-router-dom";

function ProductList() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    retrieveProducts();
  }, []);
  const retrieveProducts = () => {
    ProductService.getProducts()
      .then((response) => {
        setProducts(response.data.data);
        console.log(response.data.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };
  console.log(products);

  return (
    <div className="container">
      <h2>Products</h2>
      <button type="button" class="btn btn-success">
        <Link to="/notfound">Create Product</Link>
      </button>
      <table className="table mt-5">
        <thead className="thead-dark">
          <tr>
            <th scope="col">STT</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Price</th>
            <th scope="col">Image</th>
            <th scope="col">Option</th>
          </tr>
        </thead>
        <tbody>
          {products &&
            products.map((product, index) => (
              <tr key={index}>
                <th scope="row">{index + 1}</th>
                <td>{product.name}</td>
                <td>{product.description}</td>
                <td>{product.price}</td>
                <td>{product.image}</td>
                <td>
                  <button type="button" class="btn btn-primary">
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
}

export default ProductList;
