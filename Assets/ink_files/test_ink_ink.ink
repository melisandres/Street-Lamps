

INCLUDE other_test.ink
INCLUDE new_test.ink
VAR something = false
-> start

== start ==
narrator: this is the beginning.
{something: "And I am RIGHT.}
* [no]
player: No, I don't think so. I'm the begining.
->1_0
* [ok]
player: Okay, but it's also -only- the begining.
->1_1
* [the begining of what?]
other: You could say it's the begining.
other: You could say it's the end.
other: You could say there's nothing new under the sun.
->1_2

===1_0===
player: Anyway "it's" is not a thing,
player: "it's" is a... I don't know... a non-thing.
player: Like if you say "it's raining", what are you talking about?
other: The weather. clearly.
player: smart ass.
other: Fine. This. Is. The. Beginning.
other: Beginings can be small. The world began with only a word.
*[Did not]
player: this is not Sunday School.
->END
*[...or did it?]
player: You don't know how the world began.
narrator: How do you know?
other: I can't know. That's the whole point.
narrator: But that's where you're wrong. I can know.
->DONE
*it began with a dream
narrator: a dream that defined it.
player: la. la. la. la. la.
->DONE
//lalala


==1_1==
narrator: "begining" is only a word.
other: Yeah! It's just a word. Stop getting all weird and stuff.
narrator: Like I was saying--the begining is a concept, an idea, a word.
other: lalalala word!
narrator: don't listen to that guy. The begining isn't just a concept...
narrator: it is to concepts, as god is to men.
*[God? what do you know?]
player: It's not like you can just throw the word God out there,
player: and have that elevate your argument.
->END
*[is it? really?]
player: it is NOT. A word has no substance.
player: Anyway, how would you know?
->DONE
*and as dreams are to sleep
player: if you're lucky, your dreams will define your madness.
other: la. la. la. la. la.
->DONE

==1_2==
other: You think I'm crazy.
//player: flaky.
*[I didn't say that.]
player: Not like me.
->END
*[but I could have]
player: well. we all have a bit of crazy.
other: How would you know?
->DONE
*it begins slowly
player: , a dream that defined it.
other: la. la. la. la. la.
->DONE
