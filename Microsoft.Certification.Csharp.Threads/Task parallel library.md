# IMPLEMENT MULTITHREADING AND ASYNCHRONOUS PROCESSING
## The Task Parallel library
+ Task: an abstraction of a unit of work to be performed
+ A task may be performed concurrently with other tasks
+ *Task.Parallel* class, in *System.Threading.Tasks* namespace
### Parallel.Invoke
Accepts a number of *Action* delegates and creates a Task for each of them.
~~~
        static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }       

        public override void Execute()
        {            
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("END");
            Console.ReadKey();
        }
~~~
An *Action* delegate is an encapsulation of a method that accepts no parameters and does not return a result.
This method returns when all of the tasks have completed. We have no control on tasks' starting order.
## Paralell.Foreach
Performs a parallel implementation of the foreach loop.
Tasks are not completed in the same order that they were started.
~~~
        private static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on " + item);
            Thread.Sleep(1000);
            Console.WriteLine("Finished working on " + item);
        }

        public override void Execute()
        {
            var items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, item => { WorkOnItem(item); });
        }
~~~
## Parallel.For
Can be used to parallelize the execution of a for loop, which is governed by a control variable
~~~
        public override void Execute()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });
            Console.WriteLine("Parallel for ended");
        }

        private void WorkOnItem(int v)
        {
            Console.WriteLine("Started working on " + v);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on " + v);
        }
~~~
## Managing Parallel.For and Parallel.ForEach
The lambda expression that executes each iteration of the loop can be provided 
with an additional parameter of type `ParallelLoopState` that allows the code being
iterared to control the iteration process.

Iterations can be stopped by calling `Stop` or `Break` method on the `ParallelLoopState` variable.
+ `Stop`: requests the loop to be stopped at System's earliest convenience. Stop will 
 prevent any new iteration with an index value greater than the current index.
+ `Break`: all iterations with an index lower than current index are guaranteed to be completed. 
 No iteations with index greater than current will be started after the call to `Break`

`Stop()` is "smoother" than `Break()`.

# Parallel LINQ
PLINQ can be used to allow elements of a query to execute in parallel.

The `AsParallel()` method examines the query 
to determine if using a parallel version would speed it up. If it can't decide whether parallelization would 
improve performance the query is not executed in parallel. If you really want to use `AsParallel` you should
design the behavior with this in mind, otherwise performance may not be improved and it is possible that 
you might get the wrong outputs.

## Informing parallelization
Programs can use other method calls to further inform the parallelization process.