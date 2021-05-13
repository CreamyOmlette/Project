import React from "react";
import {Route, Switch, BrowserRouter, Link} from "react-router-dom";
import App from "../app";
import SecondPage from "../second-page";
const ParentPage = () => {
    return (
        <div className="parent-page">
            <BrowserRouter>
            <Link to="/">First</Link> 
            <Link to="/test">Second</Link>
            <Switch>
                <Route exact path="/" component={App}/>
                <Route path="/test" component={SecondPage}/>
            </Switch>     
            </BrowserRouter> 
                     
        </div>
    )
};

export default ParentPage;