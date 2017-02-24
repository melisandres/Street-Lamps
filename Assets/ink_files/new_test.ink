

//INCLUDE other_test.ink
//VAR something = false

== global_warming ==
other: ... and this is why the earth will catch fire in the next 30 years.
*[say something]
player: "..."
narrator: there's nothing to say.
->something
*[say nothing]
player: "..."
narrator: even if you were to try saying something, there's nothing to say.
->nothing
*[reconsider your life]
narrator: 30 years.. you may not even live that long.
->silence
*[focus on the positive]
narrator: winters are hard.
->positive
*[correct them]
player: "..."
narrator: what's the difference between 20 and 30 years, really.
->correction
*[keep walking]
player: "..."
narrator: that's right. Just keep walking.
->walk

=something
*but there is something to say.
narrator: right. and they just said it.->DONE
*"..."
narrator: see what I mean?->DONE
*maybe you're right.
narrator: always am.->DONE

=nothing
*I just think...
player: I just think... I mean, I care about this stuff.
player: I could talk about it with someone other than my cat.->DONE

=silence
*why wouldn't I?
player: I mean, life expectancy isn't that short.
player: Most people live into their 70's.->DONE
*why would I?
player: I'm barely surviving now.
->DONE

=positive
player: Winters ARE hard.
->DONE

=correction
*10 years. exactly.
player: Its really simple math.
->DONE

=walk
player: I intend to.
->DONE


// ==next==
// narrator: this is the beginning.
// * [no]
// player: No, I don't think so. I'm the begining.
// ->1_0
// * [ok]
// player: Okay, but it's also -only- the begining.
// ->1_1
// * [the begining of what?]
// other: You could say it's the begining.
// other: You could say it's the end.
// other: You could say there's nothing new under the sun.
// ->1_2
//
// === 1_0 ===
// player: Anyway it's is not a thing,
// player: it's is a... I don't know... a non-thing.
// player: Like if you say "it's raining", what are you talking about?
// other: The weather. clearly.
// player: smart ass.
// other: Fine. This. Is. The. Beginning.
// other: Things begin. The world began with a word.
// *[Did not]
// player: this is not Sunday School.
// ->END
// *[...or did it?]
// player: You don't know how the world began.
// narrator: How do you know?
// other: I can't know. That's the whole point.
// narrator: But that's where you're wrong. I can know.
// ->DONE
// *it began with a dream
// narrator: a dream that defined it.
// player: la. la. la. la. la.
// ->DONE
// //lalala
//
//
// ==1_1==
// narrator: "begining" is only a word.
// other: Yeah! It's just a word. Stop getting all weird and stuff.
// narrator: Like I was saying--the begining is a concept, an idea, a word.
// other: lalalala word!
// narrator: don't listen to that guy. The begining isn't just a concept...
// narrator: it is to concepts, as god is to men.
// *[God? what do you know?]
// player: It's not like you can just throw the word God out there,
// player: and have that elevate your argument.
// ->END
// *[is it? really?]
// player: it is NOT. A word has no substance.
// player: Anyway, how would you know?
// ->DONE
// *and as dreams are to sleep
// player: if you're lucky, your dreams will define your madness.
// other: la. la. la. la. la.
// ->DONE
//
// ==1_2==
// other: You think I'm crazy.
// //player: flaky.
// *[I didn't say that.]
// player: Not like me.
// ->END
// *[but I could have]
// player: well. we all have a bit of crazy.
// other: How would you know?
// ->DONE
// *it begins slowly
// player: , a dream that defined it.
// other: la. la. la. la. la.
// ->DONE
