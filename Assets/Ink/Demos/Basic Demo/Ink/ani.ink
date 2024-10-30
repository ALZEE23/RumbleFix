VAR knowledge = 0
VAR wisdom = 0
VAR empathy = 0

-> start

=== start ===
-eh sur kemana aja?
  * [selalu di tempat yang sama.]
    ~ wisdom += 0
    ~ empathy += -1
    ~ knowledge += 1
    -> weird
  
  * [ada dikelas mulu .]
    ~ wisdom += 1
    ~ empathy += 1
    ~ knowledge += 1
    -> good
    
  * [bagian kanan kelas] 
   ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
  -> weird
    
=== weird ===
- ohh gitu..
    -> DONE




=== good ===
- emang iyak ngapain dikelas?
 * [belajar sama baca buku aja.]
  ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 2
    -> good1
 * [sekolah terlalu tidak tepat sasaran]
  ~ wisdom += 1
    ~ empathy += 2
    ~ knowledge += 1
    -> weird
 * [materi yang terlalu dipaksakan]
    ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
    -> weird
    
    
=== good1 ===
- oke deh thankyou


-> END