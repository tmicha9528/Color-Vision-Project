# Overview

Welcome to the Color Vision Score App! This application aims to determine the extent to which people can see the 16.7 million colors on the RGB spectrum. To do this, users navigate three levels of color-matching and receive a score (out of 800 like the SAT), representing their overall accuracy and efficiency when matching across each level. The inner shape is colored a randomly generated RGB, so the user moves the R, G, and B sliders (all if on Level 3) to alter the outer shape's color to match the inner shape's. Users have a set amount of time and attempts for each level that factor into the final score calculation.

<div align="center">
  <img src="img/lvl3ipad.png" alt="Level 3 iPad" width="500"/>
</div>

# Technical Overview

The Color Vision Score App uses Unity's Mobile Development toolkit to build and scale the application for all mobile devices. The application was built using Unity frontend and C# backend. The application was deployed with Xcode. Here, we see the component breakdown for Level 1 of 3.

![alt text](img/lvl1unity.png)

# Application Progression

An agile development process was used to create each iteration of the application. We started with a basic prototype design to depict matching to the correct RGB.

<div align="center">
  <img src="img/version1.png" alt="Version 1 Prototype" width="550"/>
</div>

We then transitioned to an overlay design, building and modifying features based on that foundation (far more iterations in between these).

![alt text](img/progression.png)
