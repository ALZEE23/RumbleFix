VAR knowledge = 0
VAR wisdom = 0
VAR empathy = 0

-> start

=== start ===
-halo sur menurut kamu soal kemarin susah gak?
  * [bisa dibilang menantang, tapi masih bisa diatasi dengan baik.]
    ~ wisdom += 0
    ~ empathy += -1
    ~ knowledge += 1
    -> good
  
  * [bisa dipecahkan dengan usaha.]
    ~ wisdom += 1
    ~ empathy += 1
    ~ knowledge += 1
    -> weird
    
  * [seperti ujian kemudahan] 
   ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
  -> weird
    
=== weird ===
- emm agak lain yah he he
    -> DONE




=== good ===
- dibagian mana nya?
 * [saat pointer saling bertemu.]
  ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 2
    -> weird
 * [di soal nomor 2 seperti ai]
  ~ wisdom += 1
    ~ empathy += 2
    ~ knowledge += 1
    -> weird
 * [di bagian essay itu susah banget]
    ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
    -> good1
    
    
=== good1 ===
- iya sih sama, makasih sur 


-> END