# IMPLEMENT MULTITHREADING AND ASYNCHRONOUS PROCESSING
## The Task Parallel library
+ Task: an abstraction of a unit of work to be performed
+ A task may be performed concurrently with other tasks
+ *Task.Parallel* class, in *System.Threading.Tasks* namespace
### Parallel.Invoke
Accepts a number of *Action* delegates and creates a Task for each of them.

An *Action* delegate is an encapsulation of a method that accepts no parameters and does not return a result.
This method returns when all of the tasks have completed. We have no control on tasks' starting order.
## Paralell.Foreach
Performs a parallel implementation of the foreach loop.