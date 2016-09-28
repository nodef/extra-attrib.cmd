# oattrib

Get or set file or directory attributes in Windows Console.


## usage

```batch
> oattrib [options] [<path>]

:: options
:: [-f|--filetime]
:: [-u|--utc]
:: [-j|--directories]
:: [-k|--recursive]
:: [-l|--link]
:: [-y|--verbose]

:: get time attributes
:: [-c|--create]
:: [-g|--access]
:: [-w|--write]

:: set time attributes
:: [-C|--Create <creation time>]
:: [-G|--Access <last access time>]
:: [-W|--Write <last write time>]

:: clear flag attributes
:: [-a|--archive]
:: [-z|--compressed]
:: [-e|--encrypted]
:: [-h|--hidden]
:: [-v|--integrity-stream]
:: [-n|--normal]
:: [-x|--no-scrub-data]
:: [-i|--not-content-indexed]
:: [-o|--offline]
:: [-r|--read-only]
:: [-p|--reparse-point]
:: [-b|--sparse-file]
:: [-s|--system]
:: [-t|--temporary]

:: set flag attributes
:: [+a|++archive]
:: [+z|++compressed]
:: [+e|++encrypted]
:: [+h|++hidden]
:: [+v|++integrity-stream]
:: [+n|++normal]
:: [+x|++no-scrub-data]
:: [+i|++not-content-indexed]
:: [+o|++offline]
:: [+r|++read-only]
:: [+p|++reparse-point]
:: [+b|++sparse-file]
:: [+s|++system]
:: [+t|++temporary]

:: [] -> optional argument
:: <> -> argument value
```
