# FriendOrganizer
Pluralsights "Building an Enterprise App with WPF, MVVM, and Entity Framework Code First" from Thomas Claudius Huber implemented with SQLite. Only the chapter with optimistic concurrency is missing, because it's not supported by SQLite.

Ther is one minor detail that I needed to change, and that is switching the ReloadFriendAsync mehthod to a sychnronos one. I think this is a bug in the SQLite librarys.
