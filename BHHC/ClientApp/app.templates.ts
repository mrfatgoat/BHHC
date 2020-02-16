import * as angular from "angular";

// Create an angular module just for caching templates
angular.module("ClientApp.Templates", []);

import "./candidates/_candidateList.html";
import "./candidates/_candidateCard.html";

import "./reasons/_reasonList.html";