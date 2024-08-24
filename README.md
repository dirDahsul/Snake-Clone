# Snake Game - Windows Forms Project

Welcome to Snake Game, a .NET Windows Forms clone of the classic Snake game! This project is a fun and interactive implementation of the nostalgic game, featuring a variety of 'enhancements and improvements' inspired by personal takes on the genre.

## Table of Contents
1. [Introduction](#introduction)
3. [Features](#features)
4. [Controls](#controls)
5. [Gameplay](#gameplay)
6. [High Score System](#high-score-system)
7. [Pictures and Videos](#pictures-and-videos)
8. [How to Run](#how-to-run)
9. [Requirements](#requirements)
10. [Project Purpose](#project-purpose)
11. [Learning Focus](#learning-focus)
12. [Contributing](#contributing)
13. [License](#license)
14. [Acknowledgments](#acknowledgments)

## Introduction

This project was built as part of a personal journey to deepen my knowledge and expertise in software development, specifically using Windows Forms and C#, from way back in the year of 2020. By recreating the classic Snake game, I aimed to enhance my understanding of event-driven programming, graphical user interfaces, and basic game development principles. .NET, especially Windows Forms, might not be best suited for game development, but as it provided simple interface with its easy to use forms, it was easy to move forward with it.

## Features

- **Classic Gameplay**: Control the snake to eat food, thus earning points, and grow as long as possible. The objective is to achieve the highest score by avoiding collisions with the walls and the snake's own body.
- **Resizable Game Window**: The game window is fully resizable. The walls at the corners adjust automatically, allowing the player to enjoy the game at any preferred size.
- **Score Tracking**: The current score and the time elapsed since the start of the game are displayed in the upper-left corner of the game window.
- **High Score System**: After each game, the player's score can be saved with their username. The game tracks all-time high scores, displayed in a separate window sorted by rank.

## Controls

- **Arrow Keys**: Control the movement of the snake.
- **P**: Pause the game.
- **R**: Restart the game after a game over.
- **ESC**: Quit the game.

## Gameplay

- **Intro Screen**: The game starts with a welcoming intro screen that displays for 5 seconds (adjustable), featuring an animated snake and instructions on how to play.
- **Snake Movement**: Guide the snake using the arrow keys to eat food that spawns randomly on the screen. With each piece of food eaten, the snake grows longer and the score increases.
- **Food Respawn**: If food isn't eaten within 5 seconds (adjustable), it respawns in a new location.
- **Game Over**: The game ends if the snake collides with a wall or itself. An animated "Game Over" screen will appear, prompting you to press `R` to restart.

## High Score System

- **Score Submission**: After a game over, if the player's score is greater than 0, a dialog box will prompt the player to enter a username. This score will then be saved and ranked in the High Score window.
- **High Score Display**: When the game is exited, a High Score window appears displaying the all-time high scores, ranked from highest to lowest. Each entry includes the player's rank, score, and username.
- **Local Storage**: High scores are stored in a `.txt` file on the user's local machine. The scores are read from this file, sorted, and displayed in the High Score window.

## Pictures and Videos

Below are some screenshots and a video demonstration of the game in action:

### Screenshots

*(The welcoming intro screen with animated snake and game instructions.)*
![Intro Screen](https://github.com/user-attachments/assets/debbe5d7-6bb3-4b3e-b082-e3dc8ec06118)

*(In-game view showing the snake, food, score, and elapsed time.)*
![Gameplay](https://github.com/user-attachments/assets/621db2d1-ebfc-4574-91db-3db15fd4bbad)

*(The game over screen with instructions to restart or quit.)*
![Game Over Screen](https://github.com/user-attachments/assets/079b0253-be61-4b67-b4ff-78ae471e960b)

*(The player score saving feature.)*
![Player Score](https://github.com/user-attachments/assets/b0a7dba2-19ee-484e-98e9-187db8b7d6c3)

*(The highscore screen displaying the players with the highest scores.)*
![Highscore Screen](https://github.com/user-attachments/assets/0bb62cb1-9589-49db-8750-4502d0090150)

### Video

*(A short video showcasing the gameplay and features.)*

https://github.com/user-attachments/assets/f907f29d-c0d7-4c48-b95f-7f7f2d935f71

## How to Run

1. Clone the repository to your local machine. 

   ```bash
   git clone https://github.com/dirDahsul/Snake-Clone.git
   
3. Open the solution in Visual Studio or your preferred .NET IDE.
4. Build and run the project.

## Requirements

- **.NET Framework**: Ensure that the required version of the .NET Framework is installed on your machine.

## Project Purpose

This project was developed as a personal endeavor to enrich my knowledge of software development using Windows Forms and C#. By recreating a classic game, I challenged myself to explore various aspects of the .NET environment, from event-driven programming to graphical user interface design. This project serves as a testament to my ongoing commitment to advancing my coding skills. I also love classic old school games.

## Learning Focus

### Motivation

- **Love for Classic Games**: Inspired by the timeless appeal of the Snake game and classic arcade experiences.
- **Learning Experience**: Aimed to deepen my understanding of Windows Forms, C#, and event-driven programming.
- **Technical Growth**: Wanted to tackle challenges in graphical UI design, timers, and file handling.
- **Personal Achievement**: Enjoyed the process of creating a functional game while expanding my development skills.

### Technologies Used

This project was developed using a combination of the following technologies and tools:

- **C#**: The primary programming language used for developing the game logic and handling events.
- **.NET Framework**: Leveraged for building the Windows Forms application, providing the necessary libraries and support for creating a GUI.
- **Windows Forms**: Utilized for creating the graphical user interface, managing user input, and displaying the game window.
- **Timers**: Implemented for managing various timed events, such as snake movement, food respawn, and tracking elapsed time.
- **Event-Driven Programming**: Used extensively to manage interactions within the game, such as keyboard inputs and window resizing.
- **File I/O**: Employed for reading and writing high scores to a local .txt file, ensuring data persistence between game sessions.

### Lessons Learned

The development of this Snake Game was not just about recreating a beloved classic but also about exploring and mastering new technologies. My main focus was on:

- **Windows Forms**: Gaining proficiency in building user interfaces, managing controls, and handling form events, including form controls and layout management.
- **C# Programming**: Strengthening my understanding of C# syntax, object-oriented principles, and the .NET framework.
- **Event-Driven Programming**: Learning how to effectively use events and delegates to manage user interactions and game mechanics, such as responding to keyboard inputs and window resizing..
- **Timers**: Implementing multiple timers to control various aspects of the game, such as snake movement, food spawning, and time tracking.
- **Graphical Elements**: Experimenting with drawing and animating graphical elements within a Windows Forms application.
- **Data Persistence**: Saving and loading high scores using a local `.txt` file, and learning how to sort and display this data within the application. Used to ensure data persist across different gaming sessions.
- **Problem-Solving**: Faced and overcame challenges related to game development, such as ensuring the snake’s movement remained smooth and responsive.

## Future Directions

Looking forward, this project opened up several exciting avenues for further exploration and development:

- **Advanced Game Development**: Building on the foundation laid by this project, I explored more advanced game development frameworks and engines, such as Unity and Unreal Engine.
- **Exploring .NET Core**: Transitioning to .NET Core for future projects to take advantage of its cross-platform capabilities and performance improvements.
- **Improving Software Design Patterns**: Applying more sophisticated design patterns and principles, such as MVC (Model-View-Controller) or MVVM (Model-View-ViewModel), to structure future projects more effectively.
- **Collaborative Projects**: Engaging in collaborative software development projects to enhance teamwork skills and learn from other developers.
- **Expanding Skill Set**: Looking at new technologies and tools, such as cloud computing for online features.

---

This project was a first hands-on milestone in my journey as a developer in C#, allowing me to consolidate my knowledge and gain practical experience in a new programming environment.

## Contributing

This project was created as a personal endeavor, and I'm not actively seeking contributions. However, if you're interested in enhancing or modifying the project, pull requests are welcome.

## License

This project is licensed under the GPL-3.0 license License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Classic Snake game inspiration, with a focus on adding my own unique enhancements and features to this timeless classic.
- .NET documentation and community resources

Thank you for exploring my Snake Game clone project! I thoroughly enjoyed the process of developing this Windows Forms application, particularly because of my passion for classic games. This project was not only a fun challenge but also a rewarding opportunity to deepen my skills.
