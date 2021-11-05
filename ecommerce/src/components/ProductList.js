import React, { useState, useEffect } from "react";
import ProductService from "../services/product.service";
import { Link } from "react-router-dom";

function ProductList(props) {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    retrieveProducts();
  }, []);
  const retrieveProducts = () => {
    ProductService.getProducts()
      .then((response) => {
        setProducts(response.data);
        //console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };
  //console.log(products);
  const openProduct = (id) => {
    console.log(id);

    props.history.push("/products/" + id);
  };

  const deleteProduct = (id) => {
    console.log(id);
    ProductService.removeProduct(id)
      .then((response) => {
        console.log(response.data);
        retrieveProducts();
      })
      .catch((e) => {
        console.log(e);
      });
  };

  return (
    <div className="container">
      <h2>Products</h2>
      <Link to="/products/add">Create Product</Link>
      <table className="table mt-5">
        <thead className="thead-dark">
          <tr>
            <th scope="col">STT</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Price</th>
            <th scope="col">Image</th>
            <th scope="col">CreatedDate</th>
            <th scope="col">UpdateDate</th>
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
                <td>{product.createdDate}</td>
                <td>{product.updateDate}</td>
                <td>
                  <button
                    type="button"
                    class="btn btn-primary"
                    onClick={() => openProduct(product.id)}
                  >
                    Edit
                  </button>
                  <button
                    type="button"
                    class="btn btn-danger ml-2"
                    onClick={() => {
                      const confirmBox = window.confirm(
                        "Do you really want to delete this Product?"
                      );
                      if (confirmBox === true) {
                        deleteProduct(product.id);
                      }
                    }}
                  >
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
