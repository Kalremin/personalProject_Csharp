using System;
using System.Collections.Generic;
using System.Text;
/*
    0
    1
    2
    3
    4
    5
    6
    7
    8
    9

    a
    b
    c
    d
    e
    f
    g
    h
    i
    j
    k
    l
    m
    n
    o
    p
    q
    r
    s
    t
    u
    v
    w
    x
    y
    z

    A
    B
    C
    D
    E
    F
    G
    H
    I
    J
    K
    L
    M
    N
    O
    P
    Q
    R
    S
    T
    U
    V
    W
    X
    Y
    Z

    `
    ~
    !
    @
    #
    $
    %
    ^
    &
    *
    (
    )
    -
    _
    =
    +
    [
    {
    ]
    }
    ;
    :
    '
    "
    ,
    <
    .
    >
    /
    ?
    \
    |
*/
namespace RandomPwRecommand
{
    class PwRandom
    {
        enum countchar
        {
            Number=10,
            LowAlp=26,
            HighAlp=26,
            Special=32
        }

        enum lowalp
        {
            a = 10,
            b,
            c,
            d,
            e,
            f,
            g,
            h,
            i,
            j,
            k,
            l,
            m,
            n,
            o,
            p,
            q,
            r,
            s,
            t,
            u,
            v,
            w,
            x,
            y,
            z
        }
        enum highalp
        {
            A=36,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z
        }

        enum spchar
        {
        }
        
        int i;
        int temp;
        int count=93;
        
        string sendpw;

        Random random;
        public PwRandom(int i)
        {
            this.i = i;
            random = new Random();
            
        }

        public string pwrecommand(bool num,bool low, bool high, bool spec)
        {
            char[] pwchar=new char[i];
            
            for (int j=0;j<i;j++)
            {
                
                while (true)
                {
                    temp = random.Next(0, count);

                    if (!num && temp < 10)
                        continue;

                    if (!low && temp >= 10 && temp < 36)
                        continue;

                    if (!high && temp >= 36 && temp < 62)
                        continue;
                    if (!spec && temp >= 62)
                        continue;

                    break;
                }

                switch (temp)
                {
                    case 0:
                        pwchar[j] = '0';
                        break;
                    case 1:
                        pwchar[j] = '1';
                        break;
                    case 2:
                        pwchar[j] = '2';
                        break;
                    case 3:
                        pwchar[j] = '3';
                        break;
                    case 4:
                        pwchar[j] = '4';
                        break;
                    case 5:
                        pwchar[j] = '5';
                        break;
                    case 6:
                        pwchar[j] = '6';
                        break;
                    case 7:
                        pwchar[j] = '7';
                        break;
                    case 8:
                        pwchar[j] = '8';
                        break;
                    case 9:
                        pwchar[j] = '9';
                        break;
                    case 10:
                        pwchar[j] = 'a';
                        break;
                    case 11:
                        pwchar[j] = 'b';
                        break;
                    case 12:
                        pwchar[j] = 'c';
                        break;
                    case 13:
                        pwchar[j] = 'd';
                        break;
                    case 14:
                        pwchar[j] = 'e';
                        break;
                    case 15:
                        pwchar[j] = 'f';
                        break;
                    case 16:
                        pwchar[j] = 'g';
                        break;
                    case 17:
                        pwchar[j] = 'h';
                        break;
                    case 18:
                        pwchar[j] = 'i';
                        break;
                    case 19:
                        pwchar[j] = 'j';
                        break;
                    case 20:
                        pwchar[j] = 'k';
                        break;
                    case 21:
                        pwchar[j] = 'l';
                        break;
                    case 22:
                        pwchar[j] = 'm';
                        break;
                    case 23:
                        pwchar[j] = 'n';
                        break;
                    case 24:
                        pwchar[j] = 'o';
                        break;
                    case 25:
                        pwchar[j] = 'p';
                        break;
                    case 26:
                        pwchar[j] = 'q';
                        break;
                    case 27:
                        pwchar[j] = 'r';
                        break;
                    case 28:
                        pwchar[j] = 's';
                        break;
                    case 29:
                        pwchar[j] = 't';
                        break;
                    case 30:
                        pwchar[j] = 'u';
                        break;
                    case 31:
                        pwchar[j] = 'v';
                        break;
                    case 32:
                        pwchar[j] = 'w';
                        break;
                    case 33:
                        pwchar[j] = 'x';
                        break;
                    case 34:
                        pwchar[j] = 'y';
                        break;
                    case 35:
                        pwchar[j] = 'z';
                        break;
                    case 36:
                        pwchar[j] = 'A';
                        break;
                    case 37:
                        pwchar[j] = 'B';
                        break;
                    case 38:
                        pwchar[j] = 'C';
                        break;
                    case 39:
                        pwchar[j] = 'D';
                        break;
                    case 40:
                        pwchar[j] = 'E';
                        break;
                    case 41:
                        pwchar[j] = 'F';
                        break;
                    case 42:
                        pwchar[j] = 'G';
                        break;
                    case 43:
                        pwchar[j] = 'H';
                        break;
                    case 44:
                        pwchar[j] = 'I';
                        break;
                    case 45:
                        pwchar[j] = 'J';
                        break;
                    case 46:
                        pwchar[j] = 'K';
                        break;
                    case 47:
                        pwchar[j] = 'L';
                        break;
                    case 48:
                        pwchar[j] = 'M';
                        break;
                    case 49:
                        pwchar[j] = 'N';
                        break;
                    case 50:
                        pwchar[j] = 'O';
                        break;
                    case 51:
                        pwchar[j] = 'P';
                        break;
                    case 52:
                        pwchar[j] = 'Q';
                        break;
                    case 53:
                        pwchar[j] = 'R';
                        break;
                    case 54:
                        pwchar[j] = 'S';
                        break;
                    case 55:
                        pwchar[j] = 'T';
                        break;
                    case 56:
                        pwchar[j] = 'U';
                        break;
                    case 57:
                        pwchar[j] = 'V';
                        break;
                    case 58:
                        pwchar[j] = 'W';
                        break;
                    case 59:
                        pwchar[j] = 'X';
                        break;
                    case 60:
                        pwchar[j] = 'Y';
                        break;
                    case 61:
                        pwchar[j] = 'Z';
                        break;
                    case 62:
                        pwchar[j] = '`';
                        break;
                    case 63:
                        pwchar[j] = '~';
                        break;
                    case 64:
                        pwchar[j] = '!';
                        break;
                    case 65:
                        pwchar[j] = '@';
                        break;
                    case 66:
                        pwchar[j] = '#';
                        break;
                    case 67:
                        pwchar[j] = '$';
                        break;
                    case 68:
                        pwchar[j] = '%';
                        break;
                    case 69:
                        pwchar[j] = '^';
                        break;
                    case 70:
                        pwchar[j] = '&';
                        break;
                    case 71:
                        pwchar[j] = '*';
                        break;
                    case 72:
                        pwchar[j] = '(';
                        break;
                    case 73:
                        pwchar[j] = ')';
                        break;
                    case 74:
                        pwchar[j] = '-';
                        break;
                    case 75:
                        pwchar[j] = '_';
                        break;
                    case 76:
                        pwchar[j] = '=';
                        break;
                    case 77:
                        pwchar[j] = '+';
                        break;
                    case 78:
                        pwchar[j] = '[';
                        break;
                    case 79:
                        pwchar[j] = '{';
                        break;
                    case 80:
                        pwchar[j] = ']';
                        break;
                    case 81:
                        pwchar[j] = '}';
                        break;
                    case 82:
                        pwchar[j] = ';';
                        break;
                    case 83:
                        pwchar[j] = ':';
                        break;
                    case 84:
                        pwchar[j] = '\'';    
                        break;
                    case 85:
                        pwchar[j] = '"';    
                        break;
                    case 86:
                        pwchar[j] = ',';
                        break;
                    case 87:
                        pwchar[j] = '<';
                        break;
                    case 88:
                        pwchar[j] = '.';
                        break;
                    case 89:
                        pwchar[j] = '>';
                        break;
                    case 90:
                        pwchar[j] = '/';
                        break;
                    case 91:
                        pwchar[j] = '?';
                        break;
                    case 92:
                        pwchar[j] = '\\';
                        break;
                    case 93:
                        pwchar[j] = '|';
                        break;
                    default:
                        break;
                        
                }
                

            }
            sendpw = new string(pwchar);
            return sendpw;
        }
    }
}
