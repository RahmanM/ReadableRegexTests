Just reviving this code from many years back where using the Readable Regular Expression based on the idea of Jushua here http://blog.flimflan.com/ReadableRegularExpressions.html

Unfortunately cannot find the source code of this anymore but the idea had potentials!!

It would be great to use:

Regex socialSecurityNumberCheck = new Regex(Pattern.With.AtBeginning

    .Digit.Repeat.Exactly(3)

    .Literal("-").Repeat.Optional

    .Digit.Repeat.Exactly(2)

    .Literal("-").Repeat.Optional

    .Digit.Repeat.Exactly(4)

    .AtEnd);
instead of:

Regex socialSecurityNumberCheck = new Regex(@"^\d{3}-?\d{2}-?\d{4}$");

??