Feature Layer
- Each feature has it's actual test code organized in projects. A Feature is not allowed to use another feature. 
- Do not start the tests from in a Feature project. Always tests from a "Project layer" project.

+-----------+  +-----------+  +-----------+  +-----------+  +-----------+   
| Feature A |  | Feature B |  | Feature C |  | Feature D |  | Feature E |  
+-----------+  +-----------+  +-----------+  +-----------+  +-----------+  

Foundation Layer
- Base Classes
- Helper tools

Project Layer
- Create a project for each domain that needs to be tested. This allows easier segmentation of tests.
- A "Project layer" project will execute the test code placed in the Feature projects.

PageObjects
- Use Page Objects to define selectors. The PageObject file in Feature/Model has the definition.