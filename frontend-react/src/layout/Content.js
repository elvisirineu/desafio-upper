import React from "react";
import { Switch, Route } from "react-router-dom";
import Page1 from "../pages/page-1";
import Page2 from "../pages/page-2";

const Content = (props) => {
  return (
    <section className="mt-3 pl-3 pr-3">
      <Switch>
        <Route exact path="/">
          Home
        </Route>
        <Route path="/arvore">
          <Page1 />
        </Route>
        <Route path="/link-2">
          <Page2 />
        </Route>
        <Route path="/link-3">Link 3</Route>
      </Switch>
    </section>
  );
};

export default Content;
