import React from "react";

function Product(props) {
  return (
    <div className="container">
      <form>
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="inputEmail4">Name</label>
            <input
              type="email"
              class="form-control"
              id="inputEmail4"
              placeholder="Name"
            />
          </div>
          <div class="form-group col-md-6">
            <label for="inputPassword4">Quantity</label>
            <input
              type="password"
              class="form-control"
              id="inputPassword4"
              placeholder="Quantity"
            />
          </div>
        </div>
        <div class="form-group">
          <label for="inputAddress">Description</label>
          <input
            type="text"
            class="form-control"
            id="inputAddress"
            placeholder="Description"
          />
        </div>
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="inputEmail4">Price</label>
            <input
              type="email"
              class="form-control"
              id="inputEmail4"
              placeholder="Price"
            />
          </div>
          <div class="form-group col-md-6">
            <label for="inputPassword4">PromtionPrice</label>
            <input
              type="password"
              class="form-control"
              id="inputPassword4"
              placeholder="PromtionPrice"
            />
          </div>
        </div>
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="inputEmail4">Image</label>
            <input
              type="email"
              class="form-control"
              id="inputEmail4"
              placeholder="Email"
            />
          </div>
          <div class="form-group col-md-6">
            <label for="inputState">Category</label>
            <select id="inputState" class="form-control">
              <option>Tivi</option>
              <option>SmartPhone</option>
              <option>Laptop</option>
              <option>Furniture</option>
            </select>
          </div>
        </div>

        <button type="submit" class="btn btn-primary">
          Create Product
        </button>
      </form>
    </div>
  );
}

export default Product;
