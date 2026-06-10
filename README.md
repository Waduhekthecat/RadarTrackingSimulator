# Radar Tracking Simulator

A real-time radar surveillance and target tracking simulation developed in **Unity 6** using **C#**.

The Radar Tracking Simulator models a radar station operating within a two-dimensional operational area and demonstrates the fundamental concepts of target detection, tracking, probabilistic sensing, and simulation architecture commonly found in military, aerospace, and training systems.

## Documentation

Detailed design specifications, requirements, architecture diagrams, pseudocode, and test cases can be found in: 📄 [Radar Software Requirements & Design Specification](./Docs/RadarSimulatorDesignDoc.docx)

![Radar Simulator Demo](Assets/DemoLoop.gif)

---

## Overview

The simulator continuously generates and updates multiple moving targets while a radar station performs periodic scan operations to determine which targets can be detected.

Detection is influenced by several configurable factors including:

* Target distance from the radar station
* Radar detection range
* Target radar signature strength
* Environmental noise level
* Scan interval timing

The simulation provides a visual representation of radar behavior while exposing the underlying software architecture used to manage real-time simulation systems.

---

## Features

### Real-Time Target Simulation

The simulator supports multiple independently moving targets including:

* Aircraft
* Drones
* Ground Vehicles

Each target maintains:

* Position
* Heading
* Speed
* Radar Signature Strength
* Detection Status

Target movement is continuously updated throughout execution.

---

### Radar Scan Processing

The radar station performs periodic scan operations that evaluate every active target in the simulation.

For each scan cycle the system:

1. Calculates target distance from the radar station
2. Verifies whether the target is within detection range
3. Computes detection probability
4. Applies environmental noise effects
5. Determines detection results
6. Updates active track lists

Targets outside the configured radar range cannot be detected.

---

### Probabilistic Detection Model

Rather than guaranteeing detection, the simulator uses a probability-based model.

Detection probability increases when:

* Targets are closer to the radar
* Target radar signatures are stronger

Detection probability decreases when:

* Targets are farther away
* Environmental noise levels increase

This approach creates more realistic and dynamic tracking behavior while remaining computationally simple.

---

### Interactive Radar Controls

Users can modify radar operating conditions in real time.

Available controls include:

* Detection Range
* Environmental Noise Level
* Scan Interval (planned)

Changes are immediately reflected in simulator behavior and detection performance.

---

### Visual Tracking Display

The operational display provides real-time visualization of:

* Radar coverage area
* Target locations
* Detected targets
* Undetected targets
* Active detection count

Detection state changes are reflected visually after each radar scan cycle.

---

## Software Architecture

The project follows a layered object-oriented architecture consisting of:

### User Interface Layer

Responsible for:

* Visualization
* User controls
* Status displays

### Simulation Control Layer

Responsible for:

* Simulation startup
* Runtime coordination
* Scan scheduling

### Simulation Logic Layer

Responsible for:

* Target movement
* Detection calculations
* Radar processing
* Tracking management

### Data Management Layer

Responsible for:

* Target state
* Radar configuration
* Detection results
* Runtime simulation data

This separation of concerns improves maintainability, scalability, and testability.

---

## Future Enhancements

Potential future improvements include:

* Multiple radar stations
* Radar sweep visualization
* Terrain effects
* Electronic warfare simulation
* Track history trails
* Sensor fusion
* Advanced tracking filters
* 3D operational environments

---

## Technologies

* Unity 6
* C#
* Object-Oriented Design
* Real-Time Simulation
* Software Engineering Methodologies

---

## Author

Joshua Darby
GitHub: https://github.com/waduhekthecat
