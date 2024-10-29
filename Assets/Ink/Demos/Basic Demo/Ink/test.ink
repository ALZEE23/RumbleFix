// Define variables for each bar
VAR knowledge = 0
VAR wisdom = 0
VAR empathy = 0
-> start

=== start ===
Anda melihat dua pilihan di depan Anda.

* [Bantu orang asing.] 
    ~ wisdom += 1
    ~ empathy += 2
    ~ knowledge += 0.5
    Anda merasa lebih bijaksana setelah membantu orang tersebut.
    -> next

* [Abaikan orang asing.] 
    ~ empathy += -1
    ~ wisdom += 0
     ~knowledge += 0
    
    Anda merasa sedikit bersalah.
    -> next


=== next ===
Wisdom:{wisdom}
Knowledge:{knowledge}
Empathy:{empathy}
-> END
