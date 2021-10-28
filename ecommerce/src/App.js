import React, { useState, useEffect } from "react";
import { Switch, Route, Link } from "react-router-dom";
//import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import AuthService from "./services/auth.service";

import Login from "./components/Login";
import Home from "./components/Home";
import CustomerList from "./components/CustomerList";
import CategoryList from "./components/CategoryList";
import NotFound from "./components/NotFound";
import ProductList from "./components/ProductList";
import AddCategory from "./components/AddCategory";
import Category from "./components/Category";
import AddProduct from "./components/AddProduct";
import Product from "./components/Product";
const App = () => {
  const [currentUser, setCurrentUser] = useState(undefined);

  useEffect(() => {
    const user = AuthService.getCurrentUser();

    if (user) {
      setCurrentUser(user);
    }
  }, []);

  const logOut = () => {
    AuthService.logout();
  };

  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <Link to={"/"} className="navbar-brand">
          ADMIN
        </Link>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/home"} className="nav-link">
              Home
            </Link>
          </li>

          {currentUser && (
            <li className="nav-item">
              <Link to={"/customers"} className="nav-link">
                Customers
              </Link>
            </li>
          )}
          {currentUser && (
            <li className="nav-item">
              <Link to={"/categories"} className="nav-link">
                Categories
              </Link>
            </li>
          )}
          {currentUser && (
            <li className="nav-item">
              <Link to={"/products"} className="nav-link">
                Products
              </Link>
            </li>
          )}
        </div>

        {currentUser ? (
          <div className="navbar-nav ml-auto">
            <li className="nav-item">
              <Link to={"/profile"} className="nav-link">
                {currentUser.username}
              </Link>
            </li>
            <li className="nav-item">
              <a href="/login" className="nav-link" onClick={logOut}>
                LogOut
              </a>
            </li>
          </div>
        ) : (
          <div className="navbar-nav ml-auto">
            <li className="nav-item">
              <Link to={"/login"} className="nav-link">
                Login
              </Link>
            </li>

            {/* <li className="nav-item">
              <Link to={"/register"} className="nav-link">
                Sign Up
              </Link>
            </li> */}
          </div>
        )}
      </nav>

      <div className="container mt-3">
        <Switch>
          <Route exact path={["/", "/home"]} component={Home} />
          <Route exact path="/login" component={Login} />
          <Route path="/customers" component={CustomerList} />
          <Route exact path="/categories" component={CategoryList} />
          <Route path="/categories/add" component={AddCategory} />
          <Route path="/categories/:id" component={Category} />
          <Route exact path="/products" component={ProductList} />
          <Route path="/products/add" component={AddProduct} />
          <Route path="/products/:id" component={Product} />
          <Route path="/notfound" component={NotFound} />
        </Switch>
      </div>
    </div>
  );
};

export default App;
