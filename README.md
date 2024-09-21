# VR-AI Robot Training Environment

Copyright (c) 2024 VR-AI Robot Training Project by Yu-Jung, Wu

## Project Overview

This project develops a VR-AI integrated robot training environment that combines virtual reality (VR) technology with real robot control. Users can manipulate a virtual robot to observe how kinematic theories are applied in practice. The system allows learners to understand how robots achieve tasks through joint parameter settings and target position calculations. Path planning is used to avoid obstacles, and the system demonstrates how digital twins operate by synchronizing real robot movements with virtual simulations.

The project is suitable for academic research and educational purposes, offering a comprehensive platform for understanding VR-integrated robotics.

## Project Structure

### Core Control Modules

- **MainCtrl.cs**:  
  The central controller of the system, responsible for initializing all submodules and handling the synchronization between virtual and real robots. It uses inverse kinematics to calculate the joint angles for the robot's arm and control both virtual and physical robot movements.

### Virtual Robot Control

- **FakeArmCtrl.cs**:  
  Manages the control of the virtual robot arm, rotating specific joints based on button inputs to simulate real-world movements.

- **ArmBoneCtrl.cs**:  
  Controls the rotation of the robot arm’s bones, adjusting angles based on defined parameters while ensuring accurate movements within specified ranges.

- **AnimatorCtrl.cs**:  
  Handles the animation states of the virtual robot, such as moving, blowing, and other actions.

- **CrabCtrl.cs**:  
  Simulates the grabbing and movement actions of the virtual robot arm when interacting with specific objects.

### UI Control Modules

- **UIBtnPosCtrl.cs**:  
  Manages button interactions for controlling the robot’s movement to preset positions. When a button is pressed, the system automatically adjusts the arm's joint angles.

- **UItext.cs**:  
  Provides a user interface for displaying and adjusting joint angles. It updates the displayed values and syncs angle data to both virtual and physical robots.

### Real Robot Control

- **RealArmCtrl.cs**:  
  Controls the physical robot through serial communication, sending movement commands to adjust each joint's rotation based on the calculated angles.

### Path Calculation and Data Transmission

- **Inverse.cs**:  
  A module for inverse kinematics calculation, computing the required joint angles for the robot based on a given target position to ensure accurate movement in both virtual and real robots.

- **UdpSocket.cs**:  
  Manages UDP communication, receiving external data, and decoding it into object IDs, positions, and statuses. The data is then passed to other system modules for processing.

- **ObjectInfoBuffer.cs**:  
  Stores the received object data, including position, feature codes, and statuses, and manages the data within the system.

### Virtual Object Management

- **FakeItemSetCtrl.cs**:  
  Manages a set of virtual items, handling the display, hiding, and movement of objects within the virtual environment.

- **GroundSpaceCtrl.cs**:  
  Converts real-world object coordinates into their corresponding virtual world positions, ensuring proper synchronization between the physical and virtual environments.

- **MoveableItem.cs**:  
  Defines the properties of movable objects, such as position, status, and feature codes, and provides access to these attributes.

## Getting Started

### Environment Setup

1. **Import the Project**: Load all files into the Unity editor.
2. **Configure Real Robot**: Adjust the serial port settings in `RealArmCtrl.cs` to ensure proper connection with the physical robot.
3. **Run the Project**: Start the Unity scene and observe the synchronized movements of the virtual and real robot arms.

### Documentation and Support

- **Documentation**: A detailed guide is available in the `docs` folder, providing step-by-step instructions on using the system.
- **Support**: For issues or questions, please submit an issue on GitHub, and we will respond as soon as possible.
