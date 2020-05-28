Notes:

1- Foreground and Background threads are equal except that
the application will terminate if no Foreground threads are 
available

2- .NET starts by default with a single thread called "primary""
thread. However, it can create additional threads called "workers"
to execute work concurrently or parallel 

3- Multithread is about concurrency , which splits in the CPU in 
timeslices to be shared among multiple threads. That is work A and 
B can be executed toghether (A starts and B starts prior to A finishing)
even with one CPU core as the scheduler shares work

1) The work executed by a Task object typically 
executed syncronously on a thread pool rather 
than the main application.

2) Most commonly , a lambda expression is used to
specify the work that the task is to perform

3) 


References:

1- https://docs.microsoft.com/en-us/dotnet/standard/threading/

