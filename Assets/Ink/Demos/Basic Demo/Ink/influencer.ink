VAR knowledge = 0
VAR wisdom = 0
VAR empathy = 0

-> start

=== start ===
-bro eskul gak?
  * [keadaan yang selalu memaksa kehendak manusia.]
    ~ wisdom += 0
    ~ empathy += -1
    ~ knowledge += 1
    -> weird
  
  * [kayaknya gak dulu deh ada tugas.]
    ~ wisdom += 1
    ~ empathy += 1
    ~ knowledge += 1
    -> good
    
  * [ekskul adalah cara menghabiskan waktu] 
   ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
  -> weird
    
=== weird ===
- kayaknya lu sakit deh bro
    -> DONE




=== good ===
- wah tugas apa?
 * [tugas memantau manusia.]
  ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 2
    -> weird
 * [biasa matematika belum dikerjain]
  ~ wisdom += 1
    ~ empathy += 2
    ~ knowledge += 1
    -> weird
 * [memenuhi ekspektasi orang lain]
    ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
    -> weird
    
    
=== good1 ===
- waduh nextime ikut ya bro


-> END