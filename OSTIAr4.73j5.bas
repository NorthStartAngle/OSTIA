$Debug
'-  This is OSTIA 4.73j5a changes to 9 Feb 2024
'-  changes from rev 4.73j5 are only in comments! NO CHANGES TO OP CODE '
'- Check out around Line 570 for verbose
'- This is still a test VERSION to resolve USB data captureproblem, instead of using legacy RS-232c COM1
'-  CHANGE ALSO CAPTION circa line # 307; also #351,  #378, #387
'-  Clean up Graph labels33   - done
'-  PRINT updates 22 Mar 2023  -done
'-  Now prompts for ASCII output file as *.Asc, circa line # -done
'-  ASCII output to CSV file now complete, around 1156
' - Using SLOPE method to isolate PLATEAUX
'-  REMEMBER to change order of data to "Dial, Power, Resonse !!
'-  REMEMBER Pause state =(PAUSE-14), so Pause14 = 0(false) and PAUSE15=1 (TRUE
'-  Synce graphs for OSTIA Y-axis is 0-60% of 1.8, and displayed in %, around line #
'-***   https://www.youtube.com/watch?v=W8-DnP6mrVQ&list=PLW0jLmZ2j6uoKOopk8-RJfeH-YN-ckKxv&index=1&pp=iAQB
'-     shows font size manipulation
' -  still using arial mono bold as printed font.  Inconsolata 12 regular would be better, but perhaps not possible!
' -  look around line #49 for the SUB that declares font attribs
' so, "DECLARE SUB SetFont(family$ ,fontSize%,isItalic%,isBold%)" means (supposedly!) that you must declare the font (as string),
' the font size as Integer, if it's Italic as Integer, and if its BOLD as Integer
'-  Printed report spacing for arial mon bold completed (now using mostly LPRINT) -done
'-  Menu text changed - done
'- local maxima for peaks, and comparision of peaks between power and response with specified window not yet completed.
' data aquisition not yet completed for RS-232 conversion
'-  In QB64, COMMA after "Print" places each quoted item into a COLUMN (tabbed), but a SEMICOLON places them next to previous
'-  adhere to PEMDAS for math ops precedence:  (Parenthesis, Exponent, Multiply, Division, Add, Subtract)
'- 1St evaluate any sub-expression inside parentheses. Work inside to outside if more than one set.
'-  Whether inside parenthesis or not, the operator that is higher in the above list should be applied first.
'-  Also, math operations (4+5, for example) are entered as just 4+5 . Use chevron (^) for exponents, brackets for
'-  sub-quantities (ex: (5^2)+10=25, (5*2)+10=20, and 5*(2+10)=60
'-  There is no direct way to set font, size, and style for LPRINT in QB64!!  Instead, use the following sequence"
'-  SCREEN 12 (sets 640 x 480 graphics mode AND supports LPRINT text output; SCREEN 15 is 800 x 600 graphcs
'-  According to AI, a new screen space can be created, such as SCREEN _NEWIMAGE(Width,Height,Colors), or
'- "SCREEN _NEWIMAGE(1366,768,16)" , but it doesn't work for me!
'-  FONT "arial.ttf", 14,"MONOSPACED, BOLD"is the correct syntax, but the 14 isn't related to point size
'-  FEATURE to add:  Menu Item "DE-CLUTTER" selects which data to exclude from graph: Dial or Power
'-  FEATURE to add: Using inputs of "delay" and perhaps "Correlation %", have software determine the optimal Threshold value
'-  FEATURE to add: Using inputs of "Threshold" and "correlation" have software determine the optimal "delay" window size
'-  FEATURE to add: Have a pre-defined "threshold, delay, and correlation for an insurance underwriter assessment
'-  The Threshold Values asked for today, are for the PRINT-based report and are based on the "0-70" values, NOT
'-  on the 0.2 to 1.4 mw values shown in the screen plot. SOMETHING NEEDS TO BE SYNC'd. Best would be menu choice (mW or %)
'-  EXPERIMENT: Start the count of the response peaks at  ZERO, to correct peak count used for report arithmetic
DECLARE SUB DrawWindow (col%, row%, col2%, row2%, Colour%)
DECLARE SUB SuperUser (flag%)
DECLARE SUB TextualSum ()
DECLARE SUB PrintC (T$)
DECLARE SUB gets (col!, row!, Prompt$, PromptCol!, PromptBk!, EntryCol!, FieldCol!, Formats$, junk$)
DECLARE SUB Decrypt ()
DECLARE SUB Encrypt ()
DECLARE SUB PrintXYVERT (x%, y%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)
DECLARE SUB NewExam ()
DECLARE SUB CPYS ()
DECLARE SUB LoadFile ()
DECLARE SUB GraphEm ()
DECLARE SUB Titl (X1%, Y1%, X2%, Y2%, col%, Bk%, Title$, TCol%, TBk%)
DECLARE SUB MainMenu ()
DECLARE SUB OpeningTitle ()
DECLARE SUB PrintXY (x%, y%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)
DECLARE SUB PrintXYJustify (x%, y%, XEnd%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)
DECLARE SUB GetData ()
DECLARE SUB StatusLine ()
DECLARE SUB Convert (D%, Nb%)
DECLARE SUB OK (BackCol%, Msg$, NoLines%, MWidth%, MsgCol%, BoldCol%)
DECLARE FUNCTION Ntrim$ (x$)
DECLARE FUNCTION ScrollSearchMenu$ (col%, col2%, row%, MenuCol%, MenuBk%, Highlight%, MaxItem%, Default%, Default$, Title$, TitleCol%, TitleBk%, Options() AS STRING)
DECLARE FUNCTION ENC$ (T$)
DECLARE FUNCTION DDate$ ()
DECLARE FUNCTION TTime$ ()
DECLARE FUNCTION Ask$ (col%, row%, Prompt$, PromptCol%, PromptBk%, EntryCol!, FieldCol%, junk$, Formats$)
DECLARE FUNCTION ArSum(Ary() as string*1, rstart%, rend%)
DECLARE FUNCTION Dec% (Bin$)
DECLARE FUNCTION Bit$ (Decimal%)
DECLARE FUNCTION Menu$ (col%, col2%, row%, MenuCol%, MenuBk%, Highlight%, MaxItem%, Default%, Title$, TitleCol%, TitleBk%, Options() AS STRING)
DECLARE FUNCTION Edit$ (col%, row%, Prompt$, PromptCol%, PromptBk%, EntryCol%, FieldCol%, InString$, Formats$)
DECLARE FUNCTION ReadTilRet$ ()
DECLARE FUNCTION ListFiles$ (Mask$, Default$, Msg$)
DECLARE SUB Titl (x1%, y1%, x2%, y2%, col%, Bk%, Title$, TCol%, TBk%)
DECLARE SUB TextSave()
DECLARE SUB Rotates (x1, y1, x2, y2, FG, BG, orgX, orgY)
DECLARE Sub PrintString (x, y, text$, textColor,backColor,align)
DECLARE SUB SetFont(family$ ,fontSize%,isItalic%,isBold%)
DECLARE SUB PRINTS (Text$)
DECLARE Sub exitProgram ()
Type FILEDIALOGTYPE
    $If 32BIT Then
        lStructSize AS LONG '        For the DLL call
        hwndOwner AS LONG '          Dialog will hide behind window when not set correctly
        hInstance AS LONG '          Handle to a module that contains a dialog box template.
        lpstrFilter AS _OFFSET '     Pointer of the string of file filters
        lpstrCustFilter AS _OFFSET
        nMaxCustFilter AS LONG
        nFilterIndex AS LONG '       One based starting filter index to use when dialog is called
        lpstrFile AS _OFFSET '       String full of 0's for the selected file name
        nMaxFile AS LONG '           Maximum length of the string stuffed with 0's minus 1
        lpstrFileTitle AS _OFFSET '  Same as lpstrFile
        nMaxFileTitle AS LONG '      Same as nMaxFile
        lpstrInitialDir AS _OFFSET ' Starting directory
        lpstrTitle AS _OFFSET '      Dialog title
        flags AS LONG '              Dialog flags
        nFileOffset AS INTEGER '     Zero-based offset from path beginning to file name string pointed to by lpstrFile
        nFileExtension AS INTEGER '  Zero-based offset from path beginning to file extension string pointed to by lpstrFile.
        lpstrDefExt AS _OFFSET '     Default/selected file extension
        lCustData AS LONG
        lpfnHook AS LONG
        lpTemplateName AS _OFFSET
    $Else
        lStructSize As _Offset '      For the DLL call
        hwndOwner As _Offset '        Dialog will hide behind window when not set correctly
        hInstance As _Offset '        Handle to a module that contains a dialog box template.
        lpstrFilter As _Offset '      Pointer of the string of file filters
        lpstrCustFilter As Long
        nMaxCustFilter As Long
        nFilterIndex As _Integer64 '  One based starting filter index to use when dialog is called
        lpstrFile As _Offset '        String full of 0's for the selected file name
        nMaxFile As _Offset '         Maximum length of the string stuffed with 0's minus 1
        lpstrFileTitle As _Offset '   Same as lpstrFile
        nMaxFileTitle As _Offset '    Same as nMaxFile
        lpstrInitialDir As _Offset '  Starting directory
        lpstrTitle As _Offset '       Dialog title
        flags As _Integer64 '         Dialog flags
        nFileOffset As _Integer64 '   Zero-based offset from path beginning to file name string pointed to by lpstrFile
        nFileExtension As _Integer64 'Zero-based offset from path beginning to file extension string pointed to by lpstrFile.
        lpstrDefExt As _Offset '      Default/selected file extension
        lCustData As _Integer64
        lpfnHook As _Integer64
        lpTemplateName As _Offset
    $End If
End Type

Type Computer
    Time As String * 8
    Date As String * 8
End Type
' Total 16 bytes

Type patient
    SurName As String * 35
    FirstName As String * 16
    DOB As String * 8
End Type
' Total 59 bytes

Type DTAinfo
    Reserved As String * 21
    Attribute As String * 1
    FileTime As Integer
    FileDate As Integer
    FileSize As Long
    FileName As String * 13
End Type


Type Exam
    MaxPoints As String * 4
    WCB As String * 10
    InjComplaint As String * 35
    BodyPart As String * 50
    CaseNumber As String * 8
    AssesserID As String * 6
    Date As String * 8 ' Consider removal for demos
    Time As String * 8
    'Count AS STRING * 3         'not used anymore
    SampleRate As String * 3
    SampFreq As String * 3
    SampDuty As String * 3
    SampBand As String * 1
    Completed As String * 8
    VerifySurName As String * 35
End Type

Type Inquiry
    Power As String * 1
    Response As String * 1
    Pause As String * 1
    Dial As String * 1
End Type

Type RegType
    AX As Integer
    BX As Integer
    CX As Integer
    DX As Integer
    BP As Integer
    SI As Integer
    DI As Integer
    Flags As Integer
    DS As Integer
    ES As Integer
End Type

Declare Dynamic Library "comdlg32" ' Library declarations using _OFFSET types
    Function GetOpenFileNameA& (DIALOGPARAMS As FILEDIALOGTYPE) ' The Open file dialog
    Function GetSaveFileNameA& (DIALOGPARAMS As FILEDIALOGTYPE) ' The Save file dialog
End Declare

Declare Dynamic Library "user32"
    Sub SENDKEYS Alias keybd_event (ByVal bVk As Long, Byval bScan As Long, Byval dwFlags As Long, Byval dwExtraInfo As Long)
End Declare


Declare Library
    Function FindWindow& (ByVal ClassName As _Offset, WindowName$) ' To get hWnd handle
End Declare


'Dim should be (1 to MaxSize+64),technically,
'but since BASIC cannot do calculations before
Dim Shared Arr(1 To 15040) As String * 1
Dim Shared Char(0 To 255, 0 To 15) As String * 1
Common Shared EscPress
Common Shared sX As Integer, sY As Integer

'Common Shared Arr() As String * 1
Common Shared MaxSize As Integer, Xroom As Integer
Common Shared sW As Integer, sH As Integer
Const DOS = &H21
Const SetDTA = &H1A00, FindFirst = &H4E00, FindNext = &H4F00

Const Black% = 0, Blue% = 1, Green% = 2, Red% = 4
Const Cyan% = Blue% + Green%, Brown% = Green% + Red%, Magenta% = Blue% + Red%
Const White% = Blue% + Green% + Red%, Bold = 8, Gray% = Black% + Bold%
Const BrBlue% = Blue% + Bold%, BrGreen% = Green% + Bold%
Const BrRed% = Red% + Bold%, BrCyan% = Blue% + Green% + Bold%
Const Yellow% = Green% + Red% + Bold%, BrMagenta% = Blue% + Red% + Bold%
Const BrWhite% = Blue% + Green% + Red% + Bold%

Const SPACE = 32, Esc = 27, Enter = 13, TabKey = 9, ShiftTab = 15
Const Down = 80, Up = 72, LEFT = 75, RIGHT = 77
Const HOME = 71, ENDK = 79, PgDn = 81, PgUp = 73
Const INS = 82, DEL = 83, Null = 0, F1 = 59, BackSpace = 8
Const CTRLD = 4, CTRLG = 7, CTRLH = 8, CTRLS = 19, CTRLV = 22
Const CURSORON = 1, CURSOROFF = 0


Const FALSE = 0, TRUE = Not FALSE
Const Song$ = "mb t255 o1 abc o1 cba o4 cc ab ba d"

Const FALSE = 0
Const True = Not FALSE
Const OFN_ALLOWMULTISELECT = &H200& '  Allows the user to select more than one file, not recommended!
Const OFN_CREATEPROMPT = &H2000& '     Prompts if a file not found should be created(GetOpenFileName only).
Const OFN_EXTENSIONDIFFERENT = &H400& 'Allows user to specify file extension other than default extension. WONT PASS SECURIY in place now
Const OFN_FILEMUSTEXIST = &H1000& '    Checks File name exists(GetOpenFileName only).
Const OFN_HIDEREADONLY = &H4& '        Hides read-only checkbox(GetOpenFileName only)
Const OFN_NOCHANGEDIR = &H8& '         Restores the current directory to original value if user changed
Const OFN_NODEREFERENCELINKS = &H100000& 'Returns path and file name of selected shortcut(.LNK) file instead of file referenced.
Const OFN_NONETWORKBUTTON = &H20000& ' Hides and disables the Network button.
Const OFN_NOREADONLYRETURN = &H8000& ' Prevents selection of read-only files, or files in read-only subdirectory.
Const OFN_NOVALIDATE = &H100& '        Allows invalid file name characters.
Const OFN_OVERWRITEPROMPT = &H2& '     Prompts if file already exists(GetSaveFileName only)
Const OFN_PATHMUSTEXIST = &H800& '     Checks Path name exists (set with OFN_FILEMUSTEXIST).
Const OFN_READONLY = &H1& '            Checks read-only checkbox. Returns if checkbox is checked
Const OFN_SHAREAWARE = &H4000& '       Ignores sharing violations in networking
Const OFN_SHOWHELP = &H10& '           Shows the help button (useless!)
'This format includes the variables for injury complaint and bodypart
Const FHeader$ = "ASTIN Data File Format R33, Nov 4, 1996 "
Const Credit$ = "Programming by Danish, Peter, Dzmitry" ' updated 24Apr 2024
Dim Shared Machine As Computer
Dim Shared Person As patient
Dim Shared Session As Exam
Dim Shared Validation(0 To 3600) As Inquiry

Dim Shared UserAccess As Integer
Dim Shared UserAcc(1 To 10) As String * 2
Dim Shared UserName(1 To 10) As String * 3
Dim Shared UserPass(1 To 10) As String * 5
Dim Shared OfficeName As String * 35
Dim Shared OfficeAddr1 As String * 30
Dim Shared OfficeAddr2 As String * 30
Dim Shared scX As Double
Dim Shared scY As Double
Dim Shared fW As Integer, fH As Integer
Dim Shared screenImage&
Dim Shared graphMode As Integer
' $DYNAMIC

EscPress = FALSE
sW = 1366 '1920
sH = 768 '1080
scX = sW / 8 / 80: scY = sH / 16 / 25
sX = sW / 80: sY = sH / 25
MaxSize = 14976
Xroom = MaxSize / 64

' IN MEMORY
' = 4 bytes
' x 3600 = 14400

' Total MAIN file = 14657
' Note, this is raw bytes in file, that is,
' not including CR, LF, EOF, etc.
' which is about another 36... = 14693
' still comes under our alotted  14976
' Giving us about this more room   283 bytes reserved

'PROGDATA.ASTIN Data file is 20+30+50+95=195 bytes




Screen 12
Call TextSave
Screen 0
_AllowFullScreen _Stretch , _Smooth


screenImage = _NewImage(sW, sH, 256) ': _FullScreen
Screen screenImage
Do: _Limit 10: Loop Until _ScreenExists
_ScreenMove (_DesktopWidth - _Width) / 2, (_DesktopHeight - _Height) / 2
' next line is user-visible CAPTION, top-left. Make this = Line #1 and around Line # 383, 392
_Title "OSTIAr4.73j5"

On Error GoTo Errs:
On Timer(1) GoSub TimeDisp
fH = _FontHeight: fW = _PrintWidth("W")
Call OpeningTitle

Dates:
Data Jan,Feb,March,April,May,June,July,Aug,Sept,Oct,Nov,Dec

Machine.Date = Date$
Machine.Time = Time$
'GoSub TimeDisp
Call MainMenu
End

Errs:
Close #9
Close #1
Close #2
Resume Next

TimeDisp:
' Get the color and location of the cursor so we can restore it
'Call StatusLine
Return
c = CsrLin
P = Pos(0)
If P - 1 > 0 Then
    col = Screen(c, P - 1, 1)
ElseIf c > 1 Then
    col = Screen(c - 1, P, 1)
End If

Color BrWhite%, Black%

Locate c, P
Color col Mod 16, col \ 16

Return

Rem $STATIC
Sub CPYS ()
    setFont "Inter", 22, 1, 1
    PrintString 1 * sX, 1 * sY, " OSTIA System 4.73j5", Yellow%, Black%, 0
    _Font _LoadFont(Environ$("SYSTEMROOT") + "\fonts\arial.ttf", 14, "MONOSPACE,BOLD")
    ' font was "Arial.ttf",14, " MONOSPACE,BOLD"
    PrintString 1 * sX, 2 * sY, String$(80 * scX, Chr$(205)), White%, Black%, 0
    PrintString 1 * sX, 24 * sY, String$(80 * scX, Chr$(205)), White%, Black%, 0
    PrintString 1 * sX, 24.3 * sY, "(c) Copyright 1994-2023    ", White%, Black%, 0
End Sub

Sub exitProgram ()
    Cls
    setFont "Inter", 26, 1, 1
    PrintString 40 * sX, 12 * sY, "Thanks for using OSTIA ! The application is now closed.", BrWhite%, _BackgroundColor, 1
    Print #9, ENC$(Date$ + " " + Time$ + " User exited OSTIA program.")
    Close #9
    P$ = Input$(1)
    End
End Sub


Sub OpeningTitle ()
    Timer Off
    Cls

    setFont "Inter", 30, 0, 1
    Titl 5 * sX, 3 * sY, 74 * sX, 14 * sY, BrWhite%, Blue%, "OSTIA", Yellow%, Blue%
    setFont "Inter", 20, 0, 0
    PrintString sW * 0.5, 5 * sY, "Objective Injury Assessment System", BrWhite%, Blue%, 1
    PrintString sW * 0.5, 6 * sY, "Revision 4.73j5  Feb 2024", BrWhite%, Blue%, 1
    setFont "Inter", 17, 0, 0
    PrintString sW * 0.5, 7 * sY, "Copyright 1994 - 2024", BrWhite%, Blue%, 1
    PrintString sW * 0.5, 8 * sY, "All Rights Reserved", BrWhite%, Blue%, 1
    PrintString sW * 0.5, 9 * sY, "Loading ...", BrWhite%, Blue%, 1
    '    Color BrWhite%
    LogFile$ = "Log.IAS"

    Open LogFile$ For Append As #9
    Print #9, ENC$(Date$ + " " + Time$ + " OSTIA v4.73j5 Initiated")

    '    GOTO gr
    DataFile$ = "ProgData.IAS"
    Open DataFile$ For Binary As #1

    oldSize = MaxSize
    MaxSize = 274
    Xroom = MaxSize \ 64
    For i = 1 To MaxSize + 64
        Arr(i) = Input$(1, # 1)
    Next
    Close #1
    Call Decrypt

    Open "tmp1.ias" For Output As #7

    For i = 1 To MaxSize + 64
        Print #7, Arr(i);
    Next
    Close #7


    If EscPress = TRUE Then
        'For x = 1 To 100
        '      Sound x * 50, .2
        'Next
        M$ = "Security Violation!!!" + Chr$(13)
        M$ = M$ + "Integrity checks on this file have failed." + Chr$(13) + Chr$(13)
        M$ = M$ + "The file needed to load OSTIA, ~" + DataFile$ + "^," + Chr$(13)
        M$ = M$ + "has been altered or damaged in some form," + Chr$(13)
        M$ = M$ + "and will therefore not be loaded by this system."
        setFont "inter.ttf", 20, 0, 1
        OK BrRed%, M$, 6, 50, BrWhite%, BrCyan%
        Cls
        Call CPYS
        System
    End If


    MaxSize = oldSize
    Xroom = MaxSize / 64
    Open "tmp.ias" For Output As #2

    For i = 1 To MaxSize
        Print #2, Arr(i);
    Next
    Close #2


    SkEn:

    Open "tmp.ias" For Binary As #1
    'Header= 79 bytes
    'data= 195 bytes
    'file= 274 bytes
    Header$ = Input$(79, # 1)
    OfficeName = Input$(35, # 1)
    OfficeAddr1 = Input$(30, # 1)
    OfficeAddr2 = Input$(30, # 1)
    For i = 1 To 10
        UserName(i) = Input$(3, # 1)
        UserPass(i) = Input$(5, # 1)
        u$ = UserName(i)
        p$ = UserPass(i)
        UserAcc(i) = Input$(2, # 1)

    Next
    Close #1

    'Make sure they can't unerase the decrypted file
    'Shell "copy " + DataFile$ + " tmp.ias > nul"
    'Kill "tmp.ias"

    '   VB /DOS was a piece of shit for GUI
    '   try to use the nice built in GUI functions,
    '   and I can't even change the colors (some, but not all!)
    '   to my preference.  Ha, just made my own routines!
    '   Java & Python will be hugely better. Maybe J too!
    If OfficeName <> "AAMAGINE Service Industries Corp   " Then
        OfficeName = "AAMAGINE Service Industries Corp   "
        ' Add email contact info here?
        ' or here?
        OfficeAddr2 = "                              "
        OfficeAddr2 = "Toronto  Canada 416 560 1222  "
        SuperUser 1
    End If
    setFont "Inter", 24, 0, 1
    Call Titl(18 * sX, 10 * sY, 62 * sX, 14 * sY, BrWhite%, Green%, "Registered To", Yellow%, Green%)
    Color BrWhite%, Green%
    setFont "Inter", 18, 0, 0

    PrintString 40 * sX, 11 * sY, RTrim$(OfficeName), BrWhite%, Green%, 1
    'PrintString 40 * sX, 12 * sY, RTrim$(OfficeAddr1), BrWhite%, Green%, 1
    PrintString 40 * sX, 13 * sY, RTrim$(OfficeAddr2), BrWhite%, Green%, 1

    x = 0
    Do
        setFont "Inter.ttf", 20, 0, 1
        Call Titl(28 * sX, 15 * sY, 52 * sX, 20 * sY, BrWhite%, Cyan%, " Login ", BrCyan%, Cyan%)
        setFont "Inter.ttf", 17, 0, 0
        UName$ = Ask(17 * sY / fH, 31 * sX / fW, "User Name: ", BrWhite%, Cyan%, BrWhite%, Black%, "", "!!!!") ' "ptm"
        If EscPress = TRUE Then Cls: System
        UPass$ = Ask(19 * sY / fH, 31 * sX / fW, " Password: ", BrWhite%, Cyan%, Black%, Black%, "", "******") ' "danis" '
        If EscPress = TRUE Then Cls: System

        For i = 1 To 10
            If UName$ = RTrim$(UserName(i)) Then
                If UPass$ = RTrim$(UserPass(i)) Then
                    Exit Do
                End If
            End If
        Next

        Print #9, ENC$(Date$ + " " + Time$ + " Illegal Login: " + UName$ + " with pw: " + UPass$)

        PCopy 0, 1
        'Sound 100, 1

        Call DrawWindow(30 * sX, 12 * sY, 50 * sX, 16 * sY, Red%)
        'Color BrWhite%, Red%
        'Locate 12 * sX, 32 * sY
        'Print "Incorrect Login!";
        PrintString 40 * sX, 14 * sY, "Incorrect Login!", BrWhite%, Red%, 1
        If x = 3 Then
            Print #9, ENC$(Date$ + " " + Time$ + " THREE CONSECUTIVE ILLEGAL LOGONS! ")
            Close
            'Do
            '      For i = 100 To 1000 Step 10
            '            Sound i, .1
            '      Next
            'Loop
        End If
        p$ = Input$(1)
        PCopy 1, 0

        x = x + 1
        ' Exit Do
    Loop
    ' HERE'S THE SHRILL 'ANNOUNCE'
    'Sound 500, 2
    'Sound 2000, 5
    UserAccess = Val(UserAcc(i))
    Print #9, ENC$(Date$ + " " + Time$ + " " + UName$ + " logged in with security level " + Str$(UserAccess))
    'PrintString 0, 0, " ", BrWhite%, Black%, 0
    Exit Sub

    'Graphics routine

    gr:
    Cls
    z = 1
    Color White%, Black%
    'DispFont "tmsre", 5, 5, 5, BrCyan%, 1, "Diagnostic"

    Line (10 * scX \ z, 10 * scY \ z)-(635 * scX \ z, 475 * scY \ z), BrWhite%, B
    Line (8 * scX \ z, 8 * scY \ z)-(637 * scX \ z, 477 * scY \ z), White%, B

    Call PrintXY(20 * scX \ z, 30 * scY \ z, "D", 6 \ z, 6 \ z, BrCyan%, 1, 0)
    Call PrintXY(60 * scX \ z, 30 * scY \ z, "iagnostic", 5 \ z, 5 \ z, Cyan%, 1, 0)
    Call PrintXY(70 * scX \ z, 70 * scY \ z, "I", 6 \ z, 6 \ z, BrCyan%, 1, 0)
    Call PrintXY(110 * scX \ z, 70 * scY \ z, "njury", 5 \ z, 5 \ z, Cyan%, 1, 0)
    Call PrintXY(120 * scX \ z, 110 * scY \ z, "A", 6 \ z, 6 \ z, BrCyan%, 1, 0)
    Call PrintXY(160 * scX \ z, 110 * scY \ z, "ssessment", 5 \ z, 5 \ z, Cyan%, 1, 0)
    Call PrintXY(170 * scX \ z, 150 * scY \ z, "S", 6 \ z, 6 \ z, BrCyan%, 1, 0)
    Call PrintXY(210 * scX \ z, 150 * scY \ z, "ystem", 5 \ z, 5 \ z, Cyan%, 1, 0)

    Call PrintXY(250 * scX \ z, 240 * scY \ z, "Version 4.73j5  Feb 2024", 2 \ z, 2 \ z, BrWhite%, 1, 0)
    Line (240 * scX \ z, 240 * scY \ z)-(400 * scX \ z, 260 * scY \ z), White%, B

    Call PrintXY(100 * scX \ z, 350 * scY \ z, "Your product birth date is: Feb7 2024", 1 \ z, 2 \ z, White%, -1, 0)

    Call PrintXYJustify(20 * scX, 460 * scY, 620, " c Copyright 1994-4 ", 1, 1, White%, 0, 0)
    'Circle (29, 464), 6, White%

    Do While InKey$ = ""
    Loop
End Sub

Function ENC$ (T$)
    N$ = ""
    For i = 1 To Len(T$)
        N$ = N$ + Chr$(Asc(Mid$(T$, i, 1)) Xor 25)
    Next
    ENC$ = N$
End Function

Sub GetData ()
    'GetData1
    'EXIT SUB

    DefInt A-Z
    Color White%, Black%
    PCopy 0, 130
    Cls
    '256 buffer, no bin, and random (from basic terminal example) ??
    'Bin, EOFS, LFS, etc.
    'DS0-forget DSR signal

    ' COMM SESSION     ***************************
    ' originally, was: Open "COM1: 1200,N,8,1,BIN,DS0" For Random As #1 Len = 256 for RS-232c
    ' explanation:" COM1" is port name in windows
    ' Colon importance is ambiguous
    ' space bewteen colon and baud rate is ambiguous
    ' 1200 is baud date of serial data out of OSTIA box
    ' N, 8, 1 equaes to No parity; 8 data bits; 1 stop bit
    ' BIN is binary data
    ' DS0 is disregard statet of Data Set Ready
    ' Random as #1 requires further elucidation. Does it mean "whaever comes down the pipe"? What doew #1 refer to?
    ' LEN = 256 is character ength of 1 (line) record
    '   Open "USB: 1200,Nt,8,1,BIN,DSO" For Random As #1 Len = 256
    ' now is: for USB as Com3, using Prolific PL2303GC hardware adapter (REM change Device mgr stettings on Win10 Device Manager - Ports
    '**********************************************************************************

    ' New code 22 AUG 2023 -PTM via GK
    Dim bytestr As String * 256 '256 byte transfers

    port$ = "3:" ' changed from "COM3"
    'INPUT "COM port number #", port$

    GoTo jump1

    Open "COM" + port$ + "1200,N,8,1,BIN,DS0" For Random As #1 Len = 256

    'IF errnum = 0 THEN GOTO jump1:
    buf$ = ""
    reader% = 0
    counter% = 0

    Do 'main loop
        'receive data in buffer when LOC>0
        counter% = Loc(1)
        If counter% > 0 Then '******** !! Wasn't it Loc(1) if byte was in buffer??
            Get #1, , bytestr
            buf$ = Left$(bytestr, counter%)

            Print buf$: Print counter%
            reader% = reader% + counter%
        Else
            Sleep 1
        End If
        'transmit (send)

        If reader% >= 256 Then Exit Do
        k$ = InKey$
        If Len(k$) = 256 Then
            Exit Do
            k = Asc(k$)
            If k >= 32 Then 'ignore control characters)
                Print ">" + k$ + "<";
                bytestr = k$: Put #256, , bytestr
            End If
        End If
    Loop Until k$ = Chr$(27)


    Close #1:
    Print "receiver=" + Str$(reader%)
    Print "Finished"
    'end New code 22 Aug
    ' **********************************************************************************************
    jump1:

    setFont "inter", 26, 0, 1
    Call Titl(10 * sX, 4 * sY, 67 * sX, 20 * sY, BrWhite%, Blue%, " Receiving Data ", BrCyan%, Blue%)

    '    COLOR BrWhite%, Green%
    '        LOCATE 12, 30
    '            PRINT "    Percent Completed";
    '            PRINT
    Movement = 1
    'pause bit will have start and stop info
    'check pause via mux
    setFont "inter", 15, 0, 1
    Locate 12, 32 * sX
    'View Print 10 To 20
    Color Yellow%, Blue%
    Print "Waiting for status byte": Print
    Dim aa As String * 1

    Open "COM" + port$ + "1200,N,8,1,BIN,DS0" For Random As #1
    Do
        'A$ = Input$(1, # 1)
        If Loc(1) Then
            Get #1, , aa
            Locate , 20 * sX
            Color BrWhite%, Blue%
            Print , aa, Asc(aa),
            a$ = Bit(Asc(aa))
            Print a$,
            a$ = String$(8 - Len(a$), "0") + a$
            Print a$
            'From left or right? pause should be 01  or 10
            'start = 5 from left or 4?
            If Right$(a$, 2) = "01" Then
                Color Yellow%, Blue%

                Locate , 32 * sX
                Print "Waiting for start bit"
                If Mid$(a$, 4, 1) = "1" Then
                    Color Yellow%, Blue%
                    Locate , 32 * sX
                    Print "Initiating sequence . . ."
                    Exit Do
                End If
            End If
        Else
            Exit Do
        End If
    Loop

    Print
    Color Yellow%, Blue%
    Locate , 12 * sX
    Print , "Response", "Dial", "PWR/INT", "Status"
    Color BrWhite%, Blue%
    'This should be ON for communication i/o
    '    ON LOCAL ERROR GOTO 0
    For i = 1 To 3600
        'stop when io/device errror
        '        LOCATE 6, 14
        '        COLOR BrCyan%, Green%
        '        PRINT STRING$(INT(i / 72), "?");
        '        LOCATE 12, 30
        '        COLOR Yellow%, Green%
        '        PRINT INT(i / 36);
        Locate , 13
        Color BrWhite%
        'Check each independent input for muxbits
        '
        '
        '**********************************************************
        ' Here's the segment that gets the RESPONSE values from the PATIENT INPUT DEVICE
        Get #1, , Validation(i).Response 'Validation(i).Response = Input$(1, # 1)
        T$ = Bit(Asc(Validation(i).Response))
        T$ = String$(8 - Len(T$), "0") + T$
        X = 0
        Do
            X = X + 1
            If X > 360 Then Exit For ' timeout!
        Loop Until Right$(T$, 2) = "10"

        T$ = Left$(T$, 6)
        Validation(i).Response = Chr$(Dec(T$))
        If Err = 57 Then Exit For
        Print , T$, 'ASC(Validation(i).Response),
        '
        '
        '***********************************************************
        ' Here's the segment that gets the Generator DIAL values
        'Dim vd As String * 1
        'Get #1, , vd ' VD$ = Input$(1, # 1)
        Get #1, , Validation(i).Dial ' Validation(i).Dial = vd$
        T$ = Bit(Asc(Validation(i).Dial))
        T$ = String$(8 - Len(T$), "0") + T$
        X = 0
        Do
            X = X + 1
            If X > 360 Then Exit For ' timeout!
        Loop Until Right$(T$, 2) = "11"
        T$ = Left$(T$, 6)
        Validation(i).Dial = Chr$(Dec(T$))
        If Err = 57 Then Exit For
        Print T$, 'Validation(i).Dial
        '
        '
        '*********************************************************
        ' Here's the segment that gets the values for the delivered ENERGY (Power)
        Get #1, , Validation(i).Power '        Validation(i).Power = Input$(1, # 1)
        T$ = Bit(Asc(Validation(i).Power))
        T$ = String$(8 - Len(T$), "0") + T$
        X = 0
        Do
            X = X + 1
            If X > 360 Then Exit For ' timeout!
        Loop Until Right$(T$, 2) = "00"
        T$ = Left$(T$, 6)
        Validation(i).Power = Chr$(Dec(T$))
        If Err = 57 Then Exit For
        Print T$, 'ASC(Validation(i).Power),
        '
        '
        ' **************************************************************
        ' Here's the segment that gets the RESPONSE values from the patient input device
        Get #1, , Validation(i).Pause 'Validation(i).Pause = Input$(1, # 1)
        If Err = 57 Then Exit For
        T$ = Bit(Asc(Validation(i).Pause))
        T$ = String$(8 - Len(T$), "0") + T$
        X = 0
        Do
            X = X + 1
            If X > 360 Then Exit For ' timeout!
        Loop Until Right$(T$, 2) = "01"
        'If bit 3 and 4 (pause and output) are both off
        'then ending upon request..
        'bit 1, 2 = mux
        'bit 3 pause
        'bit 4 output
        'bit 5 start
        'bit 6 mode (power/intensity)
        'remember, BASIC reverses bit order, that is
        'bit 1 = bit 8, bit 2 = bit 7, bit 3 = bit 6
        'bit 4 = bit 5 ....

        'are PAUSE bit and OUTPUT both 0?
        'feb 20...
        'IF MID$(T$, 6, 1) = "0" AND MID$(T$, 5, 1) = "0" THEN
        'march 2/94.. reversing bits...
        If Mid$(T$, 3, 1) = "0" And Mid$(T$, 4, 1) = "0" Then
            Print
            Print T$
            PrintC "Ending sequence upon request."
            Exit For
        End If
        'T$ = MID$(T$, 6, 1)
        T$ = Left$(T$, 6)
        'mar 30, do we need keep track of mode, are we?
        'if no, then to fix wrong pause DISPLAY, print
        'following line, instead of T$
        '
        '
        '*****************************************************
        ' Here's the segment that gets the PAUSE bit
        Validation(i).Pause = Chr$(Dec(T$))
        Print T$; 'ASC(Validation(i).Pause);
    Next
    Session.MaxPoints = LTrim$(Str$(i))
    '    A$ = INPUT$(1)
    Close #1

    Timer Off

    FileName$ = ListFiles$("*.IAD", RTrim$(Session.CaseNumber) + ".IAD", "Save Data File")
    If FileName$ = "Cancel" = TRUE Then Exit Sub
    If Len(FileName$) = 0 Then Exit Sub
    Call Titl(23, 10, 54, 12, BrWhite%, Green%, " Saving " + FileName$ + " ... ", BrWhite%, Green%)
    Open FileName$ For Output As #1
    Machine.Date = Date$
    Machine.Time = Time$
    Print #1, Machine.Date
    Print #1, Machine.Time
    Print #1, Person.FirstName
    Print #1, Person.SurName
    Print #1, Person.DOB
    Print #1, Session.MaxPoints
    Print #1, Session.WCB
    Print #1, Session.InjComplaint
    Print #1, Session.BodyPart
    Print #1, Session.CaseNumber
    Print #1, Session.AssesserID
    Print #1, Session.Date
    Print #1, Session.Time
    'PRINT #1, Session.Count
    Print #1, Session.SampleRate
    Print #1, Session.SampFreq
    Print #1, Session.SampDuty
    Print #1, Session.SampBand
    Session.Completed = Time$
    Print #1, Session.Completed
    Print #1, Session.VerifySurName
    'Val.Dial is actually an integer, not string!
    'How can we record it's value? (between -50 to inf)
    'will save as chr$() +63 because range can be about -10 to 180 or so
    For i = 1 To 3600
        Print #1, Validation(i).Power;
        Print #1, Validation(i).Response;
        Print #1, Validation(i).Pause;
        Print #1, Validation(i).Dial;
    Next
    Close #1
    Open FileName$ For Binary As #1

    For i = 1 To MaxSize
        Arr$(i) = Input$(1, # 1)
    Next
    Close #1
    Call Encrypt
    Open FileName$ For Output As #1
    Print #1, FHeader$
    For i = 1 To MaxSize + 64
        Print #1, Arr(i);
    Next
    Close #1

    'ON LOCAL ERROR GOTO NoGraph

    'change screen only to trap error for non vga monitors
    Timer Off 'no time display in graphics mode--causes error
    'Screen 12
    graphMode = 1 'graph display from new data
    Call GraphEm
    Exit Sub 'skip error handing procedures

    ' Check the modem. If characters are waiting (EOF(1) is
    ' true), get them and print them to the screen:
    '   IF NOT EOF(1) THEN
    '
    '      ' LOC(1) gives the number of characters waiting:
    '      ModemInput$ = INPUT$(LOC(1), #1)
    '
    '      Filter ModemInput$        ' Filter out line feeds and
    '      PRINT ModemInput$;        ' backspaces, then print.
    '   END IF

    NoMoreData2:
    'Just continue, then we will check ERR for type
    'of error, if device i/o, then we know to stop
    'receiving data
    Resume Next

    ErrHandler1:
    Resume Next
    NoGraph:
    'just exit sub
    PCopy 130, 0
End Sub

DefSng A-Z
Sub GraphEm ()
    Timer Off
    'no defint because we want user to be able to input
    'decimal time in minutes
    Color , Black%
    sl = 0
    el = Val(Session.MaxPoints)

    WholeNum = TRUE
    Dim NA(0 To 3600)

    Start:

    Screen _NewImage(sW, sH, 256)
    View
    Screen
    Cls
    spX = spY = 50
    scYY = sH / 480
    Line (spX + 38 * scX, spY + 48 * scYY)-(spX + 639 * scX, spY + 402 * scYY), 15, B
    For y = 400 To 0 Step -44
        T$ = Str$(Abs(((y - 400) \ 44)) / 5) + "- "
        Call PrintXY(spX + 15 * scX, spY + (y + 3) * scYY, T$, 1, 1, White%, 1, 0)
        Line (spX + 639 * scX, spY + (y + 9) * scYY)-(spX + 38 * scX, spY + (y + 9) * scYY), 8, , 16
    Next
    Call PrintXYVERT(spX + 3 * scX, spY + 250 * scYY, "Density", 1, 1, Yellow, 0, 0) ' changed from W/cm2
    ' Call PrintXYVERT(spX + 1 * scX, spY + 210 * scYY, "2", 1, 1, Yellow, 0, 0)      ' No longer needed (part of previous label

    CT = sl / 240
    If sl = 0 Then
        CT = 0
    End If
    For X = 36 To 638 Step 600 / (el - sl) * 240
        If WholeNum = TRUE Then
            T$ = Str$(Int(CT)) + "-"
            Call PrintXYVERT(spX + (X - 2) * scX, spY + (390 + (Len(T$) * 8)) * scYY, T$, 1, 1, White%, 0, 0)
        Else
            T$ = Left$(LTrim$(Str$(CT)), 3) + "- "
            Call PrintXYVERT(spX + (X - 2) * scX, spY + (390 + (Len(T$) * 8)) * scYY, T$, 1, 1, White%, 0, 0)
        End If
        CT = CT + 1
    Next
    ' Call PrintXY(spX + 315 * scX, spY + 415 * scYY, "T I M E", 1, 1, Yellow%, 1, 0)

    Call PrintXYJustify(spX + 0, spY + 10, 150, " OSTIA System", 2, 2, Yellow%, 1, 0)


    Call PrintXY(spX + 340 * scX, spY, "Case #: ", 1, 1, White%, 1, 0) ' changed from 330
    Call PrintXY(spX + 370 * scX, spY, Session.CaseNumber, 1, 1, Yellow%, 1, 0) ' changed from 360
    ' Call PrintXY(spX + 478 * scX, spY, "Test Time: ", 1, 1, White%, 1, 0)
    If graphMode = 2 Then
        ' NEXT LINE Added *scX; changed offset from 545 to 520;  Exam.Date$,Exam.Time$ are TOD. wrong data elements!
        ' NEXT 2 LINES commented out.  This provided Time Of Day, NOY Time of Exam!
        ' Call PrintXY(spX + 520 * scX, spY, Date$ + " " + Time$, 1, 1, Yellow%, 1, 0)
        ' ElseIf graphMode <> 1 Then    ' ' commented out TEST
        '  Call PrintXY(spX + 520 * scX, spY, Session.Date + " " + Session.Time, 1, 1, Yellow%, 1, 0) ' This works now!
    End If


    Call PrintXY(spX + 330 * scX, spY + 10 * scYY, "Data Rate: ", 1, 1, White%, 1, 0)
    Call PrintXY(spX + 370 * scX, spY + 10 * scYY, Session.SampleRate, 1, 1, Yellow%, 1, 0) ' changed from 397
    Call PrintXY(spX + 478 * scX, spY + 10 * scYY, "Structure: ", 1, 1, White%, 1, 0)
    Call PrintXY(spX + 520 * scX, spY + 10 * scYY, Session.SampFreq, 1, 1, Yellow%, 1, 0)
    ' Label not needed Call PrintXY(spX + 550 * scX, spY + 10 * scYY, "D: ", 1, 1, White%, 1, 0) '
    Call PrintXY(spX + 535 * scX, spY + 10 * scYY, "/  ", 1, 1, White%, 1, 0) '
    Call PrintXY(spX + 540 * scX, spY + 10 * scYY, Session.SampDuty, 1, 1, Yellow%, 1, 0) ' reduced by 20
    ' Label not needed  Call PrintXY(spX + 600 * scX, spY + 10 * scYY, "f: ", 1, 1, White%, 1, 0) ' reduced by 15
    Call PrintXY(spX + 557 * scX, spY + 10 * scYY, "/  ", 1, 1, White%, 1, 0) '
    Call PrintXY(spX + 565 * scX, spY + 10 * scYY, Session.SampBand, 1, 1, Yellow%, 1, 0) 'reduced by 20

    'LINE (5, 20)-(10, 25), Cyan%, BF
    'CALL PrintXY(12, 20, "Paused", 1, 1, White%, 0, 0)
    'LINE (5, 30)-(10, 35), BrCyan%, BF
    'CALL PrintXY(12, 30, "Released", 1, 1, White%, 0, 0)

    Line (spX + 130 * scX, spY + 32 * scYY)-(spX + 145 * scX, spY + 38 * scYY), BrBlue%, BF
    Call PrintXY(spX + 150 * scX, spY + 30 * scYY, "PSEUDO Stim", 1, 1, White%, 1, 0)
    Line (spX + 235 * scX, spY + 32 * scYY)-(spX + 250 * scX, spY + 38 * scYY), BrWhite%, BF ' was spX+270
    Call PrintXY(spX + 255 * scX, spY + 30 * scYY, "ACTUAL Stim", 1, 1, White%, 1, 0)

    Line (spX + 335 * scX, spY + 32 * scYY)-(spX + 350 * scX, spY + 38 * scYY), Brown%, BF
    Call PrintXY(spX + 355 * scX, spY + 30 * scYY, "Patient Response", 1, 1, White%, 1, 0)
    'LINE (350, 30)-(360, 40), BrRed%, BF
    'CALL PrintXY(365, 30, "NO Correlation", 1, 1, White%, 0, 0)

    Line (spX + 485 * scX, spY + 28 * scYY)-(spX + 505 * scX, spY + 42 * scYY), BrRed%, BF
    Call PrintXY(spX + 515 * scX, spY + 30 * scYY, "ZERO STIM Condition", 1, 1, White%, 1, 0)

    Call PrintXY(spX + 150 * scX, spY + 430 * scYY, "ESC = Exit                         S = Scale                          P = Exam. Parameters", 1, 1, Yellow%, 1, 0)

    Call PrintXYJustify(spX + 20 * scX, spY + 465 * scYY, 620, " c Copyright 1994-2023", 1, 1, White%, 1, 0)
    'Circle (29, 475), 6, White%

    'CALL PrintXy(5, 432, "Pause", 1, 1, BrRed%, 0, 0)
    View (spX + 40 * scX, spY + 40 * scYY)-(spX + 638 * scX, spY + 440 * scYY)
    Window Screen(spX + sl * scX, spY + 40 * scYY)-(spX + el * scX, spY + 440 * scYY)
    'last pause bit set when ultrasound stops
    For X = sl To el - 2
        T$ = Bit(Asc(Validation(X).Pause))
        T$ = String$(8 - Len(T$), "0") + T$
        'T$ = LEFT$(T$, 1)
        'T$ = MID$(T$, 6, 1)--old
        'because last mux are removed at save,
        'then 00 is added as shown above, the new
        'placement of pause becomes the last bit, not
        'the sixth.
        T$ = Mid$(T$, 8, 1)
        If T$ = "0" Then
            'Line (x * scX + spX, 415 * scYY + spY)-(x * scX + spX, 417 * scYY + spY), BrCyan%
        Else
            Line (spX + (X - 1) * scX, spY + 398 * scYY)-(spX + (X + 2) * scX, spY + 404 * scYY), BrRed%, BF
        End If
    Next

    View (spX + 40 * scX, spY + 40 * scYY)-(spX + 638 * scX, spY + 400 * scYY)
    Window (spX + sl * scX, spY + 0)-(spX + el * scX, spY + 64 * scYY)
    ' Line (spX + 38 * scX, spY + 48 * scYY)-(spX + 639 * scX, spY + 405 * scYY), 15, B
    PSet (spX + sl * scX, spY + 0), BrWhite%
    For X = sl To el
        Line -(spX + X * scX, spY + Asc(Validation(X).Power) * scYY), BrWhite%
    Next

    For j = -1 To 1
        PSet (spX + sl, spY + 0), 0
        If el - sl = 3599 Then
            thick = j * ((el - sl) / 600)
        Else
            j = 1
            thick = 0
        End If
        For X = sl To el
            Thresh = 5
            If X > Thresh Then
                PowerDelta = Asc(Validation(X).Power) - Asc(Validation(X - Thresh).Power)
                PowerDelta = PowerDelta / Thresh
                RespDelta = Asc(Validation(X).Response) - Asc(Validation(X - Thresh).Response)
                RespDelta = RespDelta / Thresh
            End If
            Line -((X + thick) * scX + spX, spY + Asc(Validation(X).Response) * scYY), Brown%
            'END IF
        Next
    Next

    ' present logic for PEAK validation incuding OFFSETS
    NA(0) = Asc(Validation(0).Dial)
    Wrap = 0
    For X = sl To el
        If X = 0 Then X = 1

        NA(X) = NA(X - 1) + (Asc(Validation(X).Dial) - Asc(Validation(X - 1).Dial))
        If Asc(Validation(X).Dial) - Asc(Validation(X - 1).Dial) < -45 Then
            NA(X) = NA(X - 1) + (Asc(Validation(X).Dial) - Asc(Validation(X - 1).Dial) + 63)
        End If
        If Asc(Validation(X).Dial) - Asc(Validation(X - 1).Dial) > 45 Then
            NA(X) = NA(X - 1) + (Asc(Validation(X).Dial) - Asc(Validation(X - 1).Dial) - 63)
        End If
        If NA(X) > 63 Then NA(X) = 63
        If NA(X) < 0 Then NA(X) = 0

        '    END IF
        '    'Doesn't quite work yet!!!!
    Next

    PSet (spX + sl * scX, spY + 0), 0
    thick = j * ((el - sl) / 600)
    For X = sl To el
        Line -(spX + X * scX, spY + NA(X) * scYY), BrBlue%
    Next

    mode% = 0
    ' Subroutine to expand a range of data points for detailed visual review
    Do
        Select Case UCase$(InKey$)
            Case Chr$(27)
                mode% = 1
                Exit Do
            Case "S"
                Locate 29, 1
                Print Space$(70);
                Locate , 1
                Input ; "(0-15 min) Start Location: ", sl
                Input ; "         End Location: ", el
                If InStr(Str$(sl), ".") = 0 And InStr(Str$(el), ".") = 0 Then
                    WholeNum = TRUE
                Else
                    WholeNum = FALSE
                End If
                'Convert mins to points
                sl = sl * 240
                el = el * 240
                GoTo Start
            Case "P"
                PCopy 0, 160
                Window Screen(0, 0)-(sW, sH)
                'Call CPYS
                Call Titl(2 * sX, 3 * sY, 78 * sX, 22 * sY, BrWhite%, Blue%, "", BrCyan%, Blue%)
                PrintString 40 * sX, 5 * sY, " EXAMINATION DATA ", BrCyan%, Blue%, 1
                Call gets(14, 24, "           WSIB / WCB #: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.WCB, "########-!")
                Call gets(14, 74, " Case Number: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.CaseNumber, String$(8, "!"))
                Call gets(15, 24, "               Assessor: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.AssesserID, String$(6, "!"))
                Call gets(17, 24, "   Patient's First Name: ", BrWhite%, Blue%, BrWhite%, Cyan%, Person.FirstName, String$(16, "@"))
                Call gets(18, 24, "      Patient's Surname: ", BrWhite%, Blue%, BrWhite%, Cyan%, Person.SurName, String$(35, "@"))
                Call gets(19, 24, "Patient's Date of Birth: ", BrWhite%, Blue%, BrWhite%, Cyan%, Person.DOB, "##/##/##")
                'Call gets(21, 24, "      Date of This Exam: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.Date, "##/##/##")
                'Call gets(22, 24, "           Current Time: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.Time, "##:##")
                Call gets(21, 24, "       Injury Complaint: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.InjComplaint, String$(35, "!"))
                Call gets(22, 24, "   Soft-Tissue Assessed: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.BodyPart, String$(50, "!"))
                Call gets(24, 24, "              Data Rate: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.SampleRate + " Secs./Sample", String$(50, "!"))
                Call gets(25, 24, "      Pulses Per Second: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.SampFreq, String$(50, "!"))
                Call gets(24, 59, " Energy Duty Cycle: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.SampDuty + " %", String$(50, "!"))
                Call gets(25, 59, "  Energy Frequency: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.SampBand + " Mhz", String$(50, "!"))

                'Call gets(30, 24, "Machine Start Date/Time: ", White%, Blue%, BrWhite%, Blue%, Machine.Date, String$(50, "!"))
                duration = Int((Val(Session.MaxPoints) * Val(Session.SampleRate) + 120) / 60)
                'Call gets(31, 24, "   Time at End of Exam.: ", White%, Blue%, BrWhite%, Blue%, Session.Completed, String$(50, "!"))
                'Call gets(31, 64, "Estimated Exam Duration: ", White%, Blue%, BrWhite%, Blue%, Str$(duration), String$(50, "!"))

                Do
                Loop While InKey$ = ""
                PCopy 160, 0
                Timer Off
                mode% = 1
                Exit Do

        End Select
    Loop
    'Cls 0, 0
    If mode% = 0 Then
        Call TextualSum
    End If


    View: Window
    'Window Screen(0, 0)-(800, sH)
    ' Screen screenImage
    'Timer On
End Sub

Sub LoadFile ()
    DefInt A-D, F-Z

    'files will not load from a different directory.. need to add
    'path to the filename

    'Can't use csrlin and cos during gui stuff!
    TryAgain:
    FileName$ = ListFiles$("*.IAD", "", "Load Data File")
    If FileName$ = "Cancel" Or Len(FileName$) = 0 Then Exit Sub
    Call Titl(23 * sX, 10 * sY, 54 * sX, 12 * sY, BrWhite%, Brown%, " Loading " + FileName$ + " ... ", BrWhite%, Brown%)

    'GOTO SkipEnc
    Close #1
    'need to add checking for people typing in files that do not exist
    Open FileName$ For Binary As #1
    JHead$ = ReadTilRet$
    If JHead$ <> FHeader$ Then
        For X = 1 To 100
            Sound X * 50, .2
        Next
        M$ = "Incompatible DATA File Format!!!" + Chr$(13)
        M$ = M$ + "The file you have specified, " + FileName$ + "^," + Chr$(13)
        M$ = M$ + "is only for use with a previous version of OSTIA," + Chr$(13)
        M$ = M$ + "and will therefore not be loaded by this system."
        OK BrRed%, M$, 6, 50, BrWhite%, BrCyan%
        Cls
        Call CPYS
        GoTo TryAgain
    End If
    For i = 1 To MaxSize + 64
        Arr$(i) = Input$(1, # 1)
    Next
    Call Decrypt
    ''''''''''''''''''Escpres doesn't get passed
    'even though it does in ASK !!!!
    '----BECAUSE can't defint a-z on const's!!!
    'excluding E (defint a-d, f-z) works!!!
    '(on both procedure, mother and child.
    If EscPress = TRUE Then
        'For X = 1 To 100
        '      Sound X * 50, .2
        'Next
        M$ = "Security Violation!!!" + Chr$(13)
        M$ = M$ + "Integrity checks on this file have failed." + Chr$(13) + Chr$(13)
        M$ = M$ + "The file you specified to load, ~" + FileName$ + "^," + Chr$(13)
        M$ = M$ + "has been altered or damaged in some form," + Chr$(13)
        M$ = M$ + "and will therefore not be loaded by this system."
        OK BrRed%, M$, 6, 50, BrWhite%, BrCyan%
        Cls
        Call CPYS
        GoTo TryAgain
    End If


    Close #1
    Open "tmp.ias" For Output As #2

    For i = 1 To MaxSize
        Print #2, Arr(i);
    Next
    Close #2

    skipEnc:
    Open "tmp.ias" For Binary As #1
    'OPEN FileName$ FOR BINARY AS #1
    Machine.Date = ReadTilRet$
    Machine.Time = ReadTilRet$
    Person.FirstName = ReadTilRet$
    Person.SurName = ReadTilRet$
    Person.DOB = ReadTilRet$
    Session.MaxPoints = ReadTilRet$
    Session.WCB = ReadTilRet$
    Session.InjComplaint = ReadTilRet$
    Session.BodyPart = ReadTilRet$
    Session.CaseNumber = ReadTilRet$
    Session.AssesserID = ReadTilRet$
    Session.Date = ReadTilRet$
    Session.Time = ReadTilRet$
    'Session.Count = ReadTilRet$
    Session.SampleRate = ReadTilRet$
    Session.SampFreq = ReadTilRet$
    Session.SampDuty = ReadTilRet$
    Session.SampBand = ReadTilRet$
    Session.Completed = ReadTilRet$
    Session.VerifySurName = ReadTilRet$
    For i = 1 To 3600
        If EOF(1) Then Exit For
        Validation(i).Power = Input$(1, # 1)
        If EOF(1) Then Exit For
        Validation(i).Response = Input$(1, # 1)
        If EOF(1) Then Exit For
        Validation(i).Pause = Input$(1, # 1)
        If EOF(1) Then Exit For
        VD$ = Input$(1, # 1)
        'Validation(i).Dial = ASC(VD$) - 63
        Validation(i).Dial = VD$
    Next
    Print "validation limit is ="; i
    Close #1

    'Make sure they can't unerase the decrypted file
    Shell "copy " + FileName$ + " tmp.ias > nul"
    Kill "tmp.ias"

    'GoTo SkipASCII
    Cls
    '  Print #1,
    Print "   ???  Write out and save data to CSV delimited file   ???";
    Do
        A$ = InKey$
    Loop While A$ = ""
    If UCase$(A$) = "Y" Then
        Print "Working..."
        Open Left$(FileName$, InStr(FileName$, ".")) + "CSV" For Output As #1
        Print #1, "This is the CSV delimited ASCII contents of an IAD-format data file. "
        Print #1,
        Print #1, "THIS IS AN ASCII FILE WITHOUT VERITY PROTECTION AFTER GENERATION. "
        Print #1, "This is a PLAINTEXT ASCII. There's no guarantee that the characters,"
        Print #1, "and numbers haven't been altered by third parties."
        Print #1, ' line feed
        Print #1, "Time Intvl.,Dial,Power,Response,Pause" 'changed
        Print #1,
        For i = 1 To 3600
            Print #1, i, ",", (Asc(Validation(i).Dial)), ",", (Asc(Validation(i).Power)), ",", (Asc(Validation(i).Response)), ",", (Asc(Validation(i).Pause))
        Next
        Print #1,
        Print #1, "END OF FILE"
        Close #1
    End If
    SkipASCII: 'ptm
    graphMode = 2 ' graph will display from last-loadedptm data file
    Call GraphEm
End Sub

DefSng A-D, F-Z
Sub MainMenu ()
    Play "v100l64A" '"v60O1C<L40"
    DefInt A-D, F-Z
    Dim MM(1 To 15) As String
    MM(1) = " 1. Start/ Enroll a NEW ASSESSMENT          "
    MM(3) = " 2. COLLECT DATA during an assessment "
    MM(5) = " 3. DISPLAY DATA from collected data file  "
    MM(7) = " 4. PRINT TEXT REPORT from last-loaded data file  "
    MM(10) = " 8. OTHER ACTIONS                    "
    MM(12) = " 9. EXIT                             "
    If UserAccess >= 50 Then
        MM(14) = " S. *** SUPER USER ACCESS ***        "
    End If
    'in other actions, itme= print report for file#:"

    Cls 0, 0
    Color White%, Black%

    Do
        Call CPYS

        If UserAccess >= 50 Then
            Tmp$ = Menu$(5, 20, 20, BrWhite%, Blue%, Black%, 15, 1, "OSTIA Main Menu", Yellow%, Blue%, MM())
        Else
            Tmp$ = Menu$(5, 18, 20, BrWhite%, Blue%, Black%, 13, 1, "OSTIA Main Menu", Yellow%, Blue%, MM())
        End If

        Select Case Tmp$
            Case MM(1)
                Print #9, ENC$(Date$ + " " + Time$ + " User went to new exam.")
                Call NewExam
            Case MM(3)
                Print #9, ENC$(Date$ + " " + Time$ + " User went to collect data.")
                Call GetData
            Case MM(5)
                PCopy _Display, 200
                Print #9, ENC$(Date$ + " " + Time$ + " User went to load file.")
                Call LoadFile
                PCopy 200, _Display
            Case MM(7)
                Print #9, ENC$(Date$ + " " + Time$ + " User print textual summary.")
                Call TextualSum
            Case MM(10)
                Print #9, ENC$(Date$ + " " + Time$ + " User went to OTHER OPTIONS menu.")
                OK Yellow%, "Sorry! This Feature requires higher authority level ...", 1, 28, BrWhite%, Cyan%
            Case MM(12)
                exitProgram
            Case MM(14)
                Print #9, ENC$(Date$ + " " + Time$ + " User entered super user menu.")
                SuperUser 0
        End Select
    Loop
End Sub

Sub NewExam ()
    DefInt A-D, F-Z
    Color , Black%
    Cls

    Call CPYS

    For x = 0 To Val(Session.MaxPoints)
        Validation(x).Power = Chr$(0)
        Validation(x).Response = Chr$(0)
        Validation(x).Dial = Chr$(0)
        Validation(x).Pause = Chr$(0)
    Next

    over:
    EscPress = FALSE
    setFont "inter", 25, 0, 1
    Call Titl(1 * sX, 3 * sY, 78 * sX, 22 * sY, BrWhite%, Blue%, " NEW EXAMINATION ", BrCyan%, Blue%)
    '------second escape should get you back to main menu
    setFont "inter", 15, 0, 1
    Session.WCB = Ask$(5 * sY / fH, 4 * sX / fW, "           WSIB / WCB #: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.WCB, "########-!")
    If EscPress = TRUE Then GoTo over
    Session.CaseNumber = Ask$(5 * sY / fH, 54 * sX / fW, "Case Number: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.CaseNumber, String$(8, "!"))
    If EscPress = TRUE Then GoTo over
    Session.AssesserID = Ask$(6 * sY / fH, 4 * sX / fW, "               Assessor: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.AssesserID, String$(6, "!"))
    If EscPress = TRUE Then GoTo over
    Person.FirstName = Ask$(7 * sY / fH, 4 * sX / fW, "   Patient's First Name: ", BrWhite%, Blue%, BrWhite%, Cyan%, Person.FirstName, String$(16, "@"))
    If EscPress = TRUE Then GoTo over
    Person.SurName = Ask$(8 * sY / fH, 4 * sX / fW, "      Patient's Surname: ", BrWhite%, Blue%, BrWhite%, Cyan%, Person.SurName, String$(35, "@"))
    If EscPress = TRUE Then GoTo over
    Person.DOB = Ask$(9 * sY / fH, 4 * sX / fW, "Patient's Date of Birth: ", BrWhite%, Blue%, BrWhite%, Cyan%, Person.DOB, "##/##/##")
    If EscPress = TRUE Then GoTo over
    Session.Date = Ask$(10 * sY / fH, 4 * sX / fW, "      Date of This Exam: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.Date, "##/##/##")
    If EscPress = TRUE Then GoTo over
    Session.Time = Ask$(11 * sY / fH, 4 * sX / fW, "           Current Time: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.Time, "##:##")
    If EscPress = TRUE Then GoTo over
    'Session.Count = Ask$(12, 9,       " CountDown Time (Secs.): ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.Count, "###")
    'IF EscPress = TRUE THEN GOTO over

    Session.InjComplaint = Ask$(12 * sY / fH, 4 * sX / fW, "       Injury Complaint: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.InjComplaint, String$(35, "!"))
    If EscPress = TRUE Then GoTo over

    Session.BodyPart = Ask$(14 * sY / fH, 4 * sX / fW, "   Soft Tissue Assessed: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.BodyPart, String$(50, "!"))
    If EscPress = TRUE Then GoTo over

    Dim Rates(1 To 5) As String
    Rates(1) = ".25": Rates(2) = ".5 "
    Rates(3) = " 1 ": Rates(4) = " 2 "
    Rates(5) = "Oth"
    '    Color BrWhite%, Blue%
    '    Locate 17 * scX, 4 * scY: Print "            Sample Rate: ";
    PrintString 4 * sX, 15 * sY, "            Data Rate: ", BrWhite%, Blue%, 0
    Session.SampleRate = Menu$(15, 20, 29, BrWhite%, Cyan%, Black%, 5, 1, "", 0, 0, Rates())
    If Session.SampleRate = Rates(5) Then
        Session.SampleRate = Ask$(15 * sY / fH, 4 * sX / fW, "            Data Rate: ", BrWhite%, Blue%, BrWhite%, Cyan%, Session.SampleRate, "!!!")
    Else
        PrintString 25 * sX, 15 * sY, Session.SampleRate, BrWhite%, Blue%, 0
        '        Color BrWhite%, Cyan%
        '       Locate 17 * scX, 10 * scY: Print Session.SampleRate
    End If

    Rates(1) = "Contin.": Rates(2) = " 10 PPS"
    Rates(3) = "100 PPS"
    'Color BrWhite%, Blue%
    'Locate 18 * scX, 4 * scY: Print "      Pulses Per Second: ";
    PrintString 4 * sX, 17 * sY, "      Train: ", BrWhite%, Blue%, 0
    Session.SampFreq = Menu$(17, 22, 29, BrWhite%, Cyan%, Black%, 3, 2, "", 0, 0, Rates())
    '   Color BrWhite%, Cyan%
    '    Locate 18 * scX, 29 * scY: Print Session.SampFreq
    PrintString 25 * sX, 17 * sY, Session.SampFreq, BrWhite%, Blue%, 0
    ReDim Rates(1 To 10)
    Rates(1) = " 10 "
    Rates(2) = " 20 "
    Rates(3) = " 30 "
    Rates(4) = " 40 "
    Rates(5) = " 50 "
    Rates(6) = " 60 "
    Rates(7) = " 70 "
    Rates(8) = " 80 "
    Rates(9) = " 90 "
    Rates(10) = "100 "
    'Color BrWhite%, Blue%
    'Locate 19 * scX, 4 * scY: Print "      Energy Duty Cycle: ";


    PrintString 4 * sX, 18 * sY, "      Utility Factor: ", BrWhite%, Blue%, 0
    Session.SampDuty = Menu$(18, 24, 29, BrWhite%, Cyan%, Black%, 10, 5, "", 0, 0, Rates())
    If EscPress = TRUE Then GoTo over
    'Color BrWhite%, Cyan%
    'Locate 19 * scX, 12 * scY: Print Session.SampDuty
    PrintString 25 * sX, 18 * sY, Session.SampDuty, BrWhite%, Blue%, 0
    Rates(1) = " 1 ": Rates(2) = " 3 "
    '   Color BrWhite%, Blue%
    '    Locate 13 * scX, 20 * scY: Print "       Energy Frequency: ";
    PrintString 54 * sX, 6 * sY, "     Periodicity: ", BrWhite%, Blue%, 0
    Session.SampBand = Mid$(Menu$(6, 9, 70, BrWhite%, Cyan%, Black%, 2, 1, "", 0, 0, Rates()), 2, 1)
    PrintString 68 * sX, 6 * sY, Session.SampBand, BrWhite%, Blue%, 0
    Msg$ = "Ready to commence examination."
    Call OK(BrCyan%, Msg$, 0, 30, Yellow%, BrRed%)


    GetData
    Cls 0, 0
End Sub

DefInt E
Function Ntrim$ (x$)
    y$ = ""
    For x = 1 To Len(x$)
        y$ = y$ + Mid$(x$, x, 1)
        If Mid$(x$, x, 1) = Chr$(0) Then
            Exit For
        End If
    Next
    Ntrim$ = y$
End Function

DefSng A-Z
Sub NumDisp ()
    MS$ = Chr$(13)
    MS$ = MS$ + "PSEUDO Stimulations" + Chr$(13) ' changed from Number of Stimulations
    MS$ = MS$ + "   ACTUAL Stims: " + Chr$(13) ' changed from Stims generated by equip
    MS$ = MS$ + "                  DETECTED Stims: " + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "    Total Responses:" + Chr$(13)
    MS$ = MS$ + "     Correct: " + Chr$(13)
    MS$ = MS$ + "   Incorrect: " + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Number of Mixed Responses: " + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Average Response Time to Stimulation:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Mean Response Time:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Fastest Response Time:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Slowest Response Time:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Average Amplitude Variance:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Mean Amplitude Variance:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Min. Amplitude Variance:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
    MS$ = MS$ + "Max. Amplitude Variance:" + Chr$(13)
    MS$ = MS$ + Chr$(13)
End Sub



DefSng A-D, F-Z
Sub PrintC (T$)
    DefInt A-Z
    Locate , 40
    Print T$
End Sub

DefSng A-Z
Function ReadTilRet$ ()
    A$ = ""
    Do
        T$ = Input$(1, # 1)
        If T$ = Chr$(13) Then Exit Do
        A$ = A$ + T$
    Loop
    j$ = Input$(1, # 1)

    ReadTilRet$ = A$
End Function

DefInt A-Z
Sub SuperUser (flag%)
    PCopy 0, 180
    If flag% = 0 Then
        Do
            Cls
            Print
            Print
            Print "Users names, passwords, and access levels as follows:"
            For i = 1 To 10
                Print i; ": "; UserName(i); " "; i + 10; ": "; UserPass(i); " "; i + 20; ": "; UserAcc(i)
            Next
            Print
            Print "Office name and address as follows:"
            Print "50: "; OfficeName
            Print "51: "; OfficeAddr1
            Print "52: "; OfficeAddr2
            Print
            Input "Change (0=exit, 99=View Log) ?", T
            Select Case T
                Case 1 To 10
                    Input UserName(T)
                Case 11 To 20
                    Input UserPass(T - 10)
                Case 21 To 30
                    Print "50 is SuperUser"
                    Input UserAcc(T - 20)
                Case 50
                    Input OfficeName
                Case 51
                    Print "Quote your text to use commas"
                    Input OfficeAddr1
                Case 52
                    Input OfficeAddr2
                Case 99
                    'Stop Logging!
                    Close #9

                    LogFile$ = "Log.IAS"
                    Cls

                    Open LogFile$ For Input As #9
                    Do
                        Line Input #9, Tmp$
                        Print ENC(Tmp$)
                    Loop Until EOF(9)
                    Close #9

                    'Continue original logging...
                    Open LogFile$ For Append As #9
                    A$ = Input$(1)
                Case 0
                    Exit Do
            End Select
        Loop
        Print
        Print "Creating new file ..."

    End If

    DataFile$ = "ProgData.Ias"

    Open DataFile$ For Output As #1
    'Header= 79 bytes
    'data= 195 bytes
    'file= 274 bytes
    '
    Print #1, "The OSTIA System        "

    Print #1, "Version 4.7,  Mar 2023 "

    Print #1, "Programming by --many!  --"
    '"Some original structures and formats by Danish"
    Print #1, OfficeName; OfficeAddr1; OfficeAddr2;
    For i = 1 To 10
        Print #1, UserName(i); UserPass(i); UserAcc(i);
    Next
    Close #1

    oldSize = MaxSize
    MaxSize = 274
    Xroom = MaxSize \ 64

    If flag% = 0 Then Print "Encrypting ..."
    Open DataFile$ For Binary As #1

    For i = 1 To MaxSize
        Arr$(i) = Input$(1, # 1)
    Next
    Close #1
    Call Encrypt

    If flag% = 0 Then Print "Writing to file ..."
    Open DataFile$ For Output As #1
    For i = 1 To MaxSize + 64
        Print #1, Arr(i);
    Next

    MaxSize = oldSize
    Xroom = MaxSize / 64

    Close #1
    PCopy 180, 0
    '    Cls
End Sub

DefSng A-Z
Sub TextualSum ()
    Timer Off

    'G used for GoingUp/Down, T for Threshold, P's
    PCopy 0, 140
    DefInt A-F, H-O, Q-S, U-Z
    Dim peaks(1 To 64) As Integer
    Dim peaksr(1 To 64) As Integer
    Locate 1, 1
    View: Window
    Color BrWhite%, Red%
    setFont "inter", 20, 0, 1
    ' setFont only modifies screen fonts, faces, and sizes, in TEXT mode, and ALL CHARACTERS ON THE SCREEN
    ' ARE CHANGED TO THE NEW FONT
    ' QB64 defines font "sizes" in pixels, not points, so here does "Inter,20...mean 20 pixels high?
    '  0,1 might mean regular kerning, and 1 may mean BOLD,
    ' Documentation regarding the setFont command is unclear, & varies between sources


    Call Titl(20 * sX, 3 * sY, 62 * sX, 20 * sY, BrWhite%, Blue%, "TextualSummary", Yellow%, Blue%)
    setFont "inter", 16, 0, 1
    Do
        Locate 7 * scY, 35 * sX
        ' INPUT PROMPTS (3) FOR AUTOMATED ASSESMENT DECISION (Valid / Not Supported) in print report
        Input "Threshold (EmW) :   ", Thresh
        If Thresh < 0.2 Or Thresh > 1.2 Then
            IllegalChar ' typo corrected 23Apr2023
            Locate 7 * scY, 35 * sX
            Print "                            "

        Else
            Exit Do
        End If
    Loop
    Locate 9 * scY, 35 * sX
    Input "  Latency :   ", secs
    Locate 11 * scY, 35 * sX
    Input "% Correlation:   ", PosReq
    'if any of the vars are null, don't print report
    If Thresh = 0 Or secs = 0 Or PosReq = 0 Then
        Exit Sub
    End If

    'routine modified Oct 3/96
    'fix formatting, new calculation style (moving window analysis)
    'Oct 31/96
    'new way of figuring out peaks with specific filters just above

    ' MS$ = Chr$(13)
    ' ****************************************************************************************************
    ' Printed Report (Part A) starts here

    LPrint Tab(16); "OSTIA Objective Soft Tissue Injury Assessment System"
    LPrint Tab(9); "Single-Page Evaluative Analysis Report from R 4.73 j2,"
    LPrint Tab(24); " printed on " + RTrim$(Date$) + " at " + RTrim$(Time$) + "." + Chr$(13)
    LPrint Tab(5); "                    Case Number: " + Session.CaseNumber ' + Chr$(13)
    LPrint Tab(5); "    Certified OSTIA Assessor ID: " + Session.AssesserID ' + Chr$(13) ' + CHR$(13)
    LPrint Tab(5); "                          Train:" + Session.SampFreq ' + Chr$(13)
    LPrint Tab(5); "                     STIM Cycle:" + Session.SampDuty ' + " %" + Chr$(13)
    LPrint Tab(5); "                            f  : " + Session.SampBand + " Mhz" + Chr$(13) ' + Chr$(13)
    LPrint Tab(5); "         Threshold Value (EmW) :" + Str$(Thresh) ' + Chr$(13)
    LPrint Tab(5); "                  Latency (sec):" + Str$(secs) ' + Chr$(13)
    LPrint Tab(3); "  Positive Correlation Factor (%):" + Str$(PosReq) + Chr$(13) ' + Chr$(13)
    LPrint Tab(3); "This report uses only examination data, and is an objective summation of "
    LPrint Tab(3); "a soft-tissue injury assessment that employed only the OSTIA protocol"
    LPrint Tab(3); "on " + Session.Date + " at " + RTrim$(Session.Time) + "." + Chr$(13) ' + Chr$(13)

    'Hardcode installation report template for data record assessment.
    LPrint Tab(3); "This non-invasive examination of " + RTrim$(Person.FirstName) + " " + RTrim$(Person.SurName) + ", was conducted"
    LPrint Tab(3); "by " + RTrim$(Session.AssesserID); ", a certified OSTIA professional at " + RTrim$(OfficeName)
    LPrint Tab(3); "located at " + RTrim$(OfficeAddr1) + RTrim$(OfficeAddr2); "." + Chr$(13) '+ Chr$(13)

    LPrint Tab(3); "The examination used energy levels that are not detectable in healthy"
    LPrint Tab(3); "tissue, using FDA-certified and currently- calibrated equipment.  " + Chr$(13)
    LPrint Tab(3); "The exam profile data is defined as " + RTrim$(Session.SampFreq) + " /" + RTrim$(Session.SampDuty) + " /" + RTrim$(Session.SampBand) + "." + Chr$(13)
    LPrint Tab(3); "The complaint that was being investigated was '" + LTrim$(RTrim$(Session.InjComplaint)); "'"
    LPrint Tab(3); "and the specific body part being assessed was '" + LTrim$(RTrim$(Session.BodyPart)); "."
    ' + Str$(Thresh) + " , " + Str$(secs) + " , " + Str$(PosReq) + " , "
    '+ ", " + LTRIM$(RTRIM$(Session.BodyPart(2))) + ", " + LTRIM$(RTRIM$(Session.BodyPart(3))) + ", " + LTRIM$(RTRIM$(Session.BodyPart(4))) + ", and "
    '+ LTRIM$(RTRIM$(Session.BodyPart(5))) + "." + CHR$(13) + CHR$(13)
    LPrint Tab(3); "This examination lasted" + Str$(Val(Session.MaxPoints) / 4) + " seconds, and the data rate was " + Session.SampleRate + " seconds." + Chr$(13)
    LPrint Tab(3); "This examination provided an objective assessment of a claimed extant"
    LPrint Tab(3); "soft-tissue injury, and may have been immediately followed by an examination"
    LPrint Tab(3); "performed upon the contra-lateral uninjured tissue of the same subject,"
    LPrint Tab(3); "where such a counterpart exists. This protocol does not detect broken bones,"
    LPrint Tab(3); "topical sensitivity or discomfort caused by neurological disorders, as other"
    LPrint Tab(3); "diagnostic efforts better serve those investigations." + Chr$(13) 'Peer-reviewed
    '   LPrint Tab(3); "medical journals have never published claims of allergies to this to the"
    '   LPrint Tab(3); " energy or protocol anywhere in the English-speaking world." + Chr$(13) ' + Chr$(13)
    'Printed Report Part A ends Here. Parts B starts at  Line 1674
    '**************************************************************************************
    'Calculations!
    '"Granularity" is: percentage relationship of the down slope to the up slope
    'Granularity hard coded at 25%
    Granul = .25
    ' Granularity notes from 0.2:
    ' Granularity notes from 0.3:
    peak = 0
    GoingUp = 0
    GoingDown = 0
    For i = 2 To Val(Session.MaxPoints)
        'convert 0->1.6mv scale to the asc 0->64
        'IF ASC(Validation(i).Power) > Thresh * 40 THEN
        If Asc(Validation(i).Power) > Thresh * 35 Then
            If Asc(Validation(i).Power) > Asc(Validation(i - 1).Power) Then
                GoingUp = GoingUp + (Asc(Validation(i).Power) - Asc(Validation(i - 1).Power))
            ElseIf Asc(Validation(i).Power) < Asc(Validation(i - 1).Power) Then
                GoingDown = GoingDown + (Asc(Validation(i - 1).Power) - Asc(Validation(i).Power))
                'Granularity is: percentage relationship of the down slope to the
                'up slope
                If GoingDown > GoingUp * Granul Then
                    'Reset Granularity to default after using the .1 for our
                    'special condition
                    If Granul = .1 Then
                        Granul = .25
                    End If
                    peak = peak + 1
                    peaks(peak) = i

                    'Make sure we don't count the same peak twice
                    Do
                        If Asc(Validation(i).Power) > Thresh * 35 Then
                            i = i + 1
                        Else
                            Exit Do
                        End If
                    Loop
                    GoingDown = 0
                    GoingUp = 0
                End If
            End If
            'This is when there's a peak, but it goes does all of a sudden
            'below threshold and there's no chance to calculate the GoingDown
        ElseIf Asc(Validation(i).Power) = 0 And GoingUp > 5 And GoingDown < 5 Then
            peak = peak + 1
            peaks(peak) = i
            'Get out of the slum -- don't count the same peak more than once

            Do
                If Asc(Validation(i).Power) = 0 Then
                    If i < Val(Session.MaxPoints) Then
                        i = i + 1
                    Else
                        Exit Do
                    End If
                Else
                    i = i - 1
                    'Start counting the next peak
                    If Asc(Validation(i).Power) > Thresh * 35 Then
                        GoingUp = Asc(Validation(i).Power)
                        Granul = .1
                    End If
                    Exit Do
                End If
            Loop


        Else
            GoingUp = 0
            GoingDown = 0
        End If
    Next

    peakr = 0
    GoingUp = 0
    GoingDown = 0
    For i = 2 To Val(Session.MaxPoints)
        'convert 0->1.6mv scale to the asc 0->64
        'no threshold on response for now
        If Asc(Validation(i).Response) > 0 Then
            If Asc(Validation(i).Response) > Asc(Validation(i - 1).Response) Then
                GoingUp = GoingUp + (Asc(Validation(i).Response) - Asc(Validation(i - 1).Response))
            ElseIf Asc(Validation(i).Response) < Asc(Validation(i - 1).Response) Then
                GoingDown = GoingDown + (Asc(Validation(i - 1).Response) - Asc(Validation(i).Response))
                If GoingDown > GoingUp * Granul Then
                    peakr = peakr + 1
                    peaksr(peakr) = i

                    'Make sure we don't count the same peak twice
                    Do
                        If Asc(Validation(i).Response) > 0 Then
                            i = i + 1
                        Else
                            Exit Do
                        End If
                    Loop
                    GoingDown = 0
                    GoingUp = 0
                End If
            End If
        Else
            GoingUp = 0
            GoingDown = 0
        End If
    Next

    PosCor = 0
    For i = 1 To peak
        For j = 1 To peakr
            If peaks(i) <= peaksr(j) And peaksr(j) <= peaks(i) + secs * 4 Then
                PosCor = PosCor + 1
                Exit For
            End If
        Next
    Next
    If peak * (PosReq / 100) <= PosCor Then
        Decision$ = "VALID"
    Else
        Decision$ = "NOT SUPPORTED"
    End If
    '************************************************************************************
    ' Prnted Report Part B Starts Here
    'for i = 1 to 10:?peaks(i),peaksr(i):next
    LPrint Tab(3); "This examination produced" + Str$(peak) + " distinct peak instances of stimulation"
    LPrint Tab(3); "to the specific tissue identified by the subject and physically marked by"
    LPrint Tab(3); "the examiner. Our statistical analysis indicates that there were" + Str$(PosCor) + " positive"
    LPrint Tab(3); "responses to the controlled and measured stimulus."
    LPrint Tab(3); "Based solely on the ratio of positive responses in this examinaton, the"
    LPrint Tab(3); "authenticity of this patient's claims of heightened sensitivity due to"
    LPrint Tab(3); "soft tissue injury are " + Decision$ + "." + Chr$(13)

    'Ms$ = Ms$ + "The examination also found" + STR$(NegCor) + " negative responses, wherein no stimulation was applied yet the patient indicated increased sensation.  " + CHR$(13) + CHR$(13)

    LPrint Tab(3); "OSTIA-protocol assessments of soft-tissue injuries are also used to assess"
    LPrint Tab(3); "the efficacy of different therapies. Consideration must be given that this"
    LPrint Tab(3); "report may be only one in a time-series or sequence of examination reports,"
    LPrint Tab(3); "outlining changing responses in healing tissues." + Chr$(13) ' + Chr$(13)
    LPrint Tab(3); "** Please address inquiries regarding this report to the OSTIA center ** "
    LPrint Tab(3); "** by calling the number located in the 2nd paragraph of this report. **"
    '1 linefeed added for readability, Block room to add text after printing
    LPrint Tab(3); "...end...end...end...end...end...end...end...end...end...end...end...end..."
    ' Now, eject the page!
    ' MS$ = MS$ + Chr$(12)

    Filter$ = "IAD files (*.IAD)" + Chr$(0) + " *.IAD" + Chr$(0) + Chr$(0)
    Flags& = OFN_CREATEPROMPT + OFN_OVERWRITEPROMPT + OFN_NOCHANGEDIR '   add flag constants here

    'savePath$ = GetSaveFileName$("Choose Save File", ".", Filter$, 1, Flags&, _WindowHandle)
    ' *******************************************************************
    ' THIS CHUNCK REPLACED AT LINE   1517
    ' LPrint
    ' T$ = "OSTIA Soft Tissue Injury Assessment System"
    ' LPrint Space$(37 - Len(T$) / 2); T$
    ' T$ =
    ' LPrint Tab(8); "Evaluative Analysis Report printed on " + RTrim$(Date$) + " at " + RTrim$(Time$) + "." + Chr$(13)
    ' LPrint Space$(37 - Len(T$) / 2); T$: LPrint: '  LPrint Removing this LFeed should stop waste of 1 page when printing
    'We must do proper justification for printing; do not chop words at end of lines
    'LPRINT MS$    _smallzz
    '****************************************************************

    z = 0 'place on line
    For x = 1 To Len(MS$) 'for each letter in string
        'don't print null spaces unecessarily
        If Mid$(MS$, x, 1) <> Chr$(0) Then
            LPrint Mid$(MS$, x, 1);
            z = z + 1
        End If
        If Mid$(MS$, x, 1) = Chr$(13) Then 'is it a return
            LPrint "";
            z = 0
        End If
        If z >= 63 Then 'don't get to close to end ofline -- used to be 66 changed for neurological
            Do
                x = x + 1 'increment var. too!
                If Mid$(MS$, x, 1) <> Chr$(0) Then
                    LPrint Mid$(MS$, x, 1);
                    z = z + 1
                End If
                If x > Len(MS$) Then
                    z = 0
                    Exit For 'don't go forever
                End If
                If Mid$(MS$, x, 1) = Chr$(13) Then
                    z = 0
                    Exit Do
                End If
                If Mid$(MS$, x, 1) = Space$(1) Then 'must finish the word!
                    LPrint Chr$(13); "  "; ' "  " for left margin
                    z = 0
                    Exit Do
                End If
            Loop
            z = 0 'set to begining of line
        End If
    Next
    PCopy 140, 0
    Timer On

End Sub

Sub Titl (x1%, y1%, x2%, y2%, col%, Bk%, Title$, TCol%, TBk%)
    Call DrawWindow(x1%, y1%, x2%, y2%, Bk%)
    Call Box(x1% + 2, y1% + 4, x2% - 2, y2% - 2, col%, Bk%)

    Center% = (x2% + x1%) * 0.5
    Call PrintString(Center%, y1%, Title$, TCol%, TBk%, 1)
End Sub

Function Bit$ (Decimal)
    If Decimal = 0 Then N$ = "0"
    Do While Decimal > 0
        If Decimal Mod 2 Then
            N$ = "1" + N$
        Else
            N$ = "0" + N$
        End If
        Decimal = Decimal \ 2
    Loop
    Bit$ = N$
End Function

Sub Convert (D, Nb)
    Shared N$
    ' Take the remainder to find the value of the current
    ' digit.
    R = D Mod Nb
    ' If the digit is less than ten, return a digit (0...9).
    ' Otherwise, return a letter (A...Z).
    If R < 10 Then Digit$ = Chr$(R + 48) Else Digit$ = Chr$(R + 55)
    N$ = Right$(Digit$, 1) + N$


End Sub

Function Dec (Bin$)
    tmp = 0
    For y = Len(Bin$) To 1 Step -1
        If Val(Mid$(Bin$, y, 1)) = 1 Then
            tmp = tmp + 2 ^ (Len(Bin$) - y)
        End If
    Next

    Dec = tmp
End Function

Function ListFiles$ (Mask$, Default$, Msg$)
    On Error GoTo 0
    Dim ofn As FILEDIALOGTYPE
    Dim szFile As String * 260

    ' Do the Open File dialog call!
    Filter$ = "IAD Files (*.IAD)" + Chr$(0) + "*.IAD" + Chr$(0) + Chr$(0)
    Flags& = OFN_PATHMUSTEXIST Or OFN_FILEMUSTEXIST Or OFN_ALLOWMULTISELECT 'OFN_FILEMUSTEXIST + OFN_NOCHANGEDIR + OFN_READONLY + OFN_EXTENSIONDIFFERENT + OFN_OVERWRITEPROMPT '    add flag constants here

    OFile$ = GetOpenFileName$("Select a IAD File", "", Filter$, 1, Flags&, _WindowHandle)

    ListFiles$ = OFile$
End Function

Sub Encrypt ()
    'SHARED NewArr() AS STRING * 1

    'P$ = INPUT$(1)
    'Start Encryption
    For i = 1 To MaxSize Step 7
        Arr$(i) = Chr$(Asc(Arr$(i)) Xor Asc("K"))
        Arr$(i + 1) = Chr$(Asc(Arr$(i + 1)) Xor Asc("e"))
        Arr$(i + 2) = Chr$(Asc(Arr$(i + 2)) Xor Asc("y"))
        Arr$(i + 3) = Chr$(Asc(Arr$(i + 3)) Xor Asc("w"))
        Arr$(i + 4) = Chr$(Asc(Arr$(i + 4)) Xor Asc("o"))
        If i + 5 > MaxSize Then Exit For
        Arr$(i + 5) = Chr$(Asc(Arr$(i + 5)) Xor Asc("r"))
        Arr$(i + 6) = Chr$(Asc(Arr$(i + 6)) Xor Asc("d"))
    Next
    'CALL DisplayARR

    For i = 1 To MaxSize Step 2
        Swap Arr$(i), Arr$(i + 1)
    Next
    'CALL DisplayARR

    For i = 1 To MaxSize
        Arr$(i) = Chr$(255 - Asc(Arr$(i)))
    Next
    'CALL DisplayARR

    For i = 1 To MaxSize
        Arr$(i) = Chr$(Asc(Arr$(i)) Xor (i Mod 255))
    Next
    'CALL DisplayARR

    Dim CRC As Double
    x = MaxSize
    For b = 1 To MaxSize Step Xroom
        x = x + 1
        CRC = ArSum(Arr(), b, b + Xroom - 1)

        CRC = CRC Mod Xroom
        Arr$(x) = Chr$(CRC)
    Next

    'Old method of CRC within file
    'didn't work 100%, because SLIGHT adjustements in file weren't noticed
    '$DYNAMIC
    'x = 0
    'FOR i = 1 TO MaxSize
    '    IF i MOD 64 = 0 THEN
    '        CRC = ArSum(Arr(), x - 62, x)
    '        CRC = CRC \ 64
    '        NewArr(i) = CHR$(CRC)
    '    ELSE
    '        x = x + 1
    '        IF x >= MaxSize - XRoom + 2 THEN EXIT FOR
    '        NewArr(i) = Arr(x)
    '    END IF
    'NEXT
    'FOR i = 1 TO MaxSize
    '    Arr(i) = NewArr(i)
    'NEXT
    'DisplayARR

    'This block of code only works with TEXT only encryption, not binary.
    'FOR j = 1 TO MaxSize-XRoom STEP 255
    '   FOR i = j TO j + 126
    '      ARR(i) = CHR$(ASC(ARR(i)) - 126)
    '   NEXT
    'NEXT
    'CALL DisplayARR

End Sub

Sub PrintXY (Xpos, Ypos, text$, Xsize, Ysize, FG, Slant%, Tilt%)
    orgX = Xpos: orgY = Ypos
    x = Xpos: y = Ypos: Xoff = (8 * Xsize): L = Len(text$)
    'If BG Then 'set BackGround if not 0
    '    Line (x - (2 * Xsize), y - Ysize)-(x + (L * Xoff), y + (16 * Ysize)), BG, BF
    'End If
    For character = 1 To L 'go through text chars
        tx = Asc(Mid$(text$, character, 1)) 'get ASCII value
        For r = 0 To 15 'current row of 16
            For c = 0 To 7 '                       'cycle through 8 bit values
                If Asc(Char(tx, r)) And 2 ^ c Then 'if bit is on
                    If Slant% = 0 Then
                        Call Rotates(x, y, x + Xsize - 1, y + Ysize - 1, FG, BF, orgX, orgY)
                    Else
                        Line (x, y)-(x + Xsize - 1, y + Ysize - 1), FG, B
                    End If

                End If 'adapted from code by TerryRitchie @ www.QB64.net
                x = x + Xsize 'move x position
            Next c 'next bit
            y = y + Ysize 'move y position
            x = Xpos 'reset column position
        Next r
        y = Ypos 'reset y position
        Xpos = Xpos + Xoff 'set to next character column
    Next character 'next character

End Sub

Sub PrintXYJustify (x%, y%, XEnd%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)

    Call PrintXY(x%, y%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)
    Exit Sub
    Dim p(9, 9)
    Def Seg = &HF000

    a = 0
    XtrSpc = 0
    For Letter = 1 To Len(Text$)

        AN = &HFA6E + 8 * Asc(Mid$(Text$, Letter)) - 1
        For i = 1 To 8
            N = Peek(AN + i)
            If N >= 128 Then N = N - 128: p(i, 1) = 1 Else p(i, 1) = 0
            If N >= 64 Then N = N - 64: p(i, 2) = 1 Else p(i, 2) = 0
            If N >= 32 Then N = N - 32: p(i, 3) = 1 Else p(i, 3) = 0
            If N >= 16 Then N = N - 16: p(i, 4) = 1 Else p(i, 4) = 0
            If N >= 8 Then N = N - 8: p(i, 5) = 1 Else p(i, 5) = 0
            If N >= 4 Then N = N - 4: p(i, 6) = 1 Else p(i, 6) = 0
            If N >= 2 Then N = N - 2: p(i, 7) = 1 Else p(i, 7) = 0
            If N >= 1 Then p(i, 8) = 1 Else p(i, 8) = 0
        Next i

        For xx = 1 To 8
            For yy = 1 To 8
                If p(yy, xx) > 0 Then
                    Block = 8 * SizeX * (Letter - 1)
                    x1 = x + Block + xx * SizeX + (yy * Slant) - (a * SizeX) + (XtrSpc * SizeX)
                    x2 = x + Block + xx * SizeX + SizeX + (yy * Slant) - (a * SizeX) + (XtrSpc * SizeX)
                    y1 = y + yy * SizeY
                    y2 = y + yy * SizeY + SizeY
                    If SizeX > 1 Or SizeY > 1 Then
                        '+1 Makes it more crisp!
                        Line (x1 + 1, y1 + 1)-(x2, y2), Colour, BF
                        'LINE (x1, y1)-(x2, y2), Colour, BF
                    Else
                        PSet (x1, y1), Colour
                    End If
                End If
            Next
            y = y + Tilt

        Next

        'Get rid of those EXTRA spaces
        For ii = 8 To 4 Step -1 'between each letter...
            b = 0
            For t = 1 To 8
                If p(t, ii) = 0 Then
                    b = b + 1
                Else
                    Exit For
                End If
            Next
            If b = 8 Then
                a = a + 1
            End If
        Next


        If Letter <> Len(Text$) Then
            '                                  \/ DA- 08/25/92 --Since a(kerning) is dynamic, it is
            '                                  \| difficult to estimate the remaining space to calc-
            '                                  .. ulate justification.  6 is used as an approximate
            '                                   ` averager, but the length of a letter can vary from
            '                                   | a mere 3 to a full 9.
            XtrSpc = XtrSpc + (((XEnd% - x2) - (6 * SizeX * (Len(Text$) - Letter))) / (Len(Text$) - Letter))
        Else
            XtrSpc = 0
        End If


    Next

End Sub


Sub PrintXYVERT (x%, y%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)
    Call PrintXY(x%, y%, Text$, SizeX%, SizeY%, Colour%, Slant%, Tilt%)
    Exit Sub
    Dim p(9, 9)
    Def Seg = &HF000

    For Letter = 1 To Len(Text$)

        AN = &HFA6E + 8 * Asc(Mid$(Text$, Letter)) - 1
        For i = 1 To 8
            N = Peek(AN + i)
            If N >= 128 Then N = N - 128: p(i, 1) = 1 Else p(i, 1) = 0
            If N >= 64 Then N = N - 64: p(i, 2) = 1 Else p(i, 2) = 0
            If N >= 32 Then N = N - 32: p(i, 3) = 1 Else p(i, 3) = 0
            If N >= 16 Then N = N - 16: p(i, 4) = 1 Else p(i, 4) = 0
            If N >= 8 Then N = N - 8: p(i, 5) = 1 Else p(i, 5) = 0
            If N >= 4 Then N = N - 4: p(i, 6) = 1 Else p(i, 6) = 0
            If N >= 2 Then N = N - 2: p(i, 7) = 1 Else p(i, 7) = 0
            If N >= 1 Then p(i, 8) = 1 Else p(i, 8) = 0
        Next i

        For xx = 1 To 8
            For yy = 1 To 8
                If p(xx, 8 - yy) > 0 Then
                    Block = 8 * SizeY * (Letter - 1)
                    x1 = x + xx * SizeX
                    x2 = x + xx * SizeX + SizeX
                    y1 = y - Block + yy * SizeY + (xx * Slant)
                    y2 = y - Block + yy * SizeY + SizeY + (xx * Slant)
                    If SizeX > 1 And SizeY > 1 Then
                        Line (x1, y1)-(x2, y2), Colour, BF
                    Else
                        PSet (x1, y1), Colour
                    End If
                End If
            Next
            y = y + Tilt
        Next

    Next

End Sub

Sub gets (col, row, Prompt$, PromptCol, PromptBk, EntryCol, FieldCol, Formats$, junk$)

    'This function is made just to allow the programmer to put a prompt
    'and string at specific locations on the screen in specific colors
    'all in just one line

    Locate col, row
    Color PromptCol, PromptBk
    Print Prompt$;
    Color EntryCol, FieldCol
    Print Formats$; " ";

End Sub

Sub OK (BackCol%, Msg$, NoLines%, MWidth%, MsgCol%, BoldCol%)
    PCopy 0, 110
    TopLine% = 8
    BotLine% = 8 + NoLines% + 3

    Lbeg% = 38 - MWidth% / 2
    Lend% = 42 + MWidth% / 2
    Call Titl(Lbeg% * sX, TopLine% * sY, Lend% * sX, BotLine% * sY, BackCol%, BoldCol%, "", MsgCol%, BoldCol%)
    setFont "inter.ttf", 15, 0, 1
    'For i = 1 To Len(Msg$)
    '    Select Case Mid$(Msg$, i, 1)
    '        Case "~"
    '            Color BoldCol%
    '        Case "^"
    '            Color MsgCol%
    '        Case Chr$(13)
    '            Locate CsrLin + 1, Lbeg% + 3
    '        Case Else
    '            PrintString sW / 2, 13 * sY, Mid$(Msg$, i, 1), MsgCol%, BackCol%, 1
    '    End Select
    'Next
    PrintString sW / 2, (TopLine% + BotLine%) / 2 * sY, Msg$, MsgCol%, BoldCol%, 1
    '    PrintString (BotLine% - 1) * sX, (Lend% - 8) * sY, "  OK  ", BackCol%, BoldCol%, 1
    Do
    Loop While InKey$ <> Chr$(13)
    PCopy 110, 0
End Sub

Sub Decrypt ()
    EscPress = FALSE
    Dim CRC As Double
    x = MaxSize
    For b = 1 To MaxSize Step Xroom
        x = x + 1
        CRC = ArSum(Arr(), b, b + Xroom - 1)
        CRC = CRC Mod Xroom
        'added june 12, don't know why it wasn't here before...
        'but worked before without it!!??
        If x > MaxSize + 64 Then Exit For
        Print CRC: Print "=": Print Chr$(CRC): Print

        If Arr(x) <> Chr$(CRC) Then
            EscPress = TRUE
            'CRC ERROR!
            Exit Sub
        End If
    Next

    For i = 1 To MaxSize
        Arr$(i) = Chr$(Asc(Arr$(i)) Xor (i Mod 255))
    Next
    'CALL DisplayARR

    For i = 1 To MaxSize
        Arr$(i) = Chr$(255 - Asc(Arr$(i)))
    Next
    'CALL DisplayARR

    For i = 1 To MaxSize Step 2
        Swap Arr(i), Arr(i + 1)
    Next
    'CALL DisplayARR

    For i = 1 To MaxSize Step 7
        Arr$(i) = Chr$(Asc(Arr$(i)) Xor Asc("K"))
        Arr$(i + 1) = Chr$(Asc(Arr$(i + 1)) Xor Asc("e"))
        Arr$(i + 2) = Chr$(Asc(Arr$(i + 2)) Xor Asc("y"))
        Arr$(i + 3) = Chr$(Asc(Arr$(i + 3)) Xor Asc("w"))
        Arr$(i + 4) = Chr$(Asc(Arr$(i + 4)) Xor Asc("o"))
        If i + 5 > MaxSize Then Exit For
        Arr$(i + 5) = Chr$(Asc(Arr$(i + 5)) Xor Asc("r"))
        Arr$(i + 6) = Chr$(Asc(Arr$(i + 6)) Xor Asc("d"))
    Next
    'CALL DisplayARR
End Sub

Function Menu$ (col%, col2%, row%, MenuCol%, MenuBk%, Highlight%, MaxItem%, Default%, Title$, TitleCol%, TitleBk%, Options() As String)

    Timer Stop
    'Check the maximum width
    Tmp = 0
    For i = 1 To MaxItem%
        If Tmp < Len(Options(i)) + 1 Then
            Tmp = Len(Options(i)) + 1
        End If
    Next
    Highlighted% = -1
    MWidth% = Tmp

    'Set the default option
    On Error GoTo 0
    For i = Default% To MaxItem%
        If Options(i) <> "" Then
            Highlighted% = i
            Exit For
        End If
    Next
    If Highlighted% = -1 Then
        hightlighted = 1
    End If

    'Save screen
    PCopy 0, 30
    NLine% = col%
    NPos% = row%

    BView% = 1
    EView% = col2% - col%

    'Make scroll b0ar if all the menu can't be seen
    If EView% < MaxItem% * scY Then
        Scroll% = TRUE
    End If

    Scroll% = FALSE
    If Title$ <> "" Then
        'Make the window bigger to satisfy the title space


        If Scroll% = TRUE Then
            Call DrawWindow(NPos% * sX, NLine% * sY, (NPos% + MWidth% + 2) * sX, (col2% + 3) * sY, MenuBk%)
        Else
            Call DrawWindow(NPos% * sX, NLine% * sY, (NPos% + MWidth%) * sX, (col2% + 2) * sY, MenuBk%)
        End If

        setFont "inter", 18, 0, 1
        Color TitleCol%, TitleBk%
        Locate NLine%, (NPos% + 1)
        'Print String$((MWidth% - 1) * scX, "_");
        PrintString (NPos% + 1) * sX, NLine% * sY, String$(MWidth% * sX * 1.3 / fW, "_"), TitleCol%, TitleBk%, 0

        Locate (NLine% + 1), (NPos% + 1)
        _Font 14
        For i% = 1 To (MWidth% - Len(Title$)) * sX * 1.3 / fW
            If i Mod 2 = 0 Then
                demote$ = demote$ + Chr$(30)
            Else
                demote$ = demote$ + Chr$(31)
            End If
        Next
        PrintString (NPos% + 1) * sX, (NLine% + 1) * sY, demote$, TitleCol%, TitleBk%, 0

        Locate , NPos% + 1 + (MWidth% - Len(Title$)) * scX
        setFont "inter", 18, 0, 1
        PrintString (NPos% + MWidth%) * sX, (NLine% + 1) * sY, Title$, TitleCol%, TitleBk%, 2
        NLine% = NLine% + 2
    Else
        If Scroll% = TRUE Then
            Call DrawWindow(NPos% * sX, NLine% * sY, (NPos% + MWidth% + 2) * sX, (col2% + 3) * sY, MenuBk%)
        Else
            Call DrawWindow(NPos% * sX, NLine% * sY, (NPos% + MWidth%) * sX, (col2% + 2) * sY, MenuBk%)
        End If
    End If

    setFont "inter.ttf", 16, 0, 1
    GoSub RedrawOptions

    Do
        A$ = InKey$
        Select Case A$
            Case Chr$(13), Chr$(TabKey), Chr$(Null) + Chr$(ShiftTab)
                If A$ = Chr$(TabKey) Or A$ = Chr$(13) Then
                    FieldNum = FieldNum + 1
                    If FieldNum > MaxFieldNum Then FieldNum = 1
                Else
                    FieldNum = FieldNum - 1
                    If FieldNum < 1 Then FieldNum = MaxFiledNum
                End If
                Menu$ = Options(Highlighted%)
                PCopy 30, 0
                Exit Function
            Case Chr$(0) + Chr$(72)
                Highlighted% = Highlighted% - 1
                If Highlighted% = 0 Then Highlighted% = MaxItem%
                If Options(Highlighted%) = "" Then
                    Highlighted% = Highlighted% - 1
                    If Highlighted% = 0 Then Highlighted% = MaxItem%
                End If
                If Options(Highlighted%) = "" Then Highlighted% = Highlighted% - 1
                If Highlighted% < BView% Then
                    BView% = Highlighted%
                    EView% = Highlighted% + (col2% - col% - 1)
                    GoSub RedrawOptions
                End If
                If Highlighted% > EView% Then
                    EView% = Highlighted%
                    BView% = Highlighted% - (col2% - col% - 1)
                    GoSub RedrawOptions
                End If
                GoSub RedrawOptions
            Case Chr$(0) + Chr$(80)
                Highlighted% = Highlighted% + 1
                If Highlighted% = MaxItem% + 1 Then Highlighted% = 1
                If Options(Highlighted%) = "" Then
                    Highlighted% = Highlighted% + 1
                    If Highlighted% = MaxItem% + 1 Then Highlighted% = 1
                End If
                If Options(Highlighted%) = "" Then Highlighted% = Highlighted% + 1
                If Highlighted% > EView% Then
                    EView% = Highlighted%
                    BView% = Highlighted% - (col2% - col% - 1)
                    GoSub RedrawOptions
                End If
                If Highlighted% < BView% Then
                    BView% = Highlighted%
                    EView% = Highlighted% + (col2% - col% - 1)
                    GoSub RedrawOptions
                End If
                GoSub RedrawOptions
            Case Chr$(Null) + Chr$(75)
                'If in a pull-down menu, change menus
                If PullDownTF = TRUE Then
                    PullItem = PullItem - 1
                    If PullItem = 0 Then PullItem = MaxPullItem
                    Menu$ = ""
                    PCopy 30, 0
                    Exit Function
                End If
            Case Chr$(0) + Chr$(77)
                If PullDownTF = TRUE Then
                    PullItem = PullItem + 1
                    If PullItem > MaxPullItem Then PullItem = 1
                    Menu$ = ""
                    PCopy 30, 0
                    Exit Function
                End If
            Case Else
                'Dec.29/95 Quick&Dirty revision
                'allows the user to use a hotkey, that is
                'the second character in each of the menu
                'items
                For i = 1 To MaxItem%
                    If UCase$(A$) = Mid$(Options(i), 2, 1) And Options(i) <> "" Then
                        Menu$ = Options(i)
                        PCopy 30, 0
                        Exit Function
                    End If
                Next
        End Select

    Loop

    'Print each of the menu items
    RedrawOptions:
    If Scroll% = TRUE Then
        'Turn Elevator% into a percentage out of TotBar%
        TotBar% = EView% - BView%
        Elevator% = Int(Highlighted% / MaxItem% * 100)
        Tmp% = 100 / TotBar%
        Elevator% = Elevator% / Tmp%
    End If

    For i% = BView% To EView% - 1
        Locate (NLine% + i% - BView% + 1), (NPos% + 1)

        'Check to see if it is currently selected
        If Highlighted% = i% Then
            'Color MenuCol%, Highlight%
            fc% = MenuCol%: bc% = Hightlight%
        Else
            'Color MenuCol%, MenuBk%
            fc% = MenuCol%: bc% = MenuBk%
        End If



        If Options(i%) = "" Then
            'Print Space$((MWidth% - 1) * sX / fW)
            PrintString ((NPos% + 1)) * sX, (NLine% + i% - BView%) * sY, Space$((MWidth% - 1) * sX / fW), fc%, bc%, 0

        Else
            'Print Options(i%);
            PrintString ((NPos% + 1)) * sX, (NLine% + i% - BView%) * sY, Options(i%), fc%, bc%, 0
        End If

        If Scroll% = TRUE Then
            'Color TitleCol%, TitleBk%
            'Locate NLine%, NPos% + MWidth% + 1
            'Print "?";
            PrintString ((NPos% + MWidth% + 1)) * sX, NLine% * sY, "?", TitleCol%, TitleBk%, 0

            'Locate col2% + 3, NPos% + MWidth% + 1
            'Print "?";
            PrintString ((NPos% + MWidth% + 1)) * sX, (col2% + 3) * sY, "?", TitleCol%, TitleBk%, 0
            'Locate NLine% + i% - BView% + 1, NPos% + MWidth% + 1
            If i% - BView% = Elevator% Then
                'Print "?";

            Else
                'Print "?";
            End If
            PrintString ((NPos% + MWidth% + 1)) * sX, (NLine% + i% - BView% + 1) * sY, "?", TitleCol%, TitleBk%, 0
        End If
    Next
    Return

End Function

Function Ask$ (row, col, Prompt$, PromptCol, PromptBk, EntryCol, FieldCol, junk$, Formats$)
    ' Formats$ =====================
    ' @ Alphabetical
    ' # Numerical
    ' ! Alphabetical or Numberical
    ' Others are constant in string

    '_Font _LoadFont(Environ$("SYSTEMROOT") + "\fonts\Arial.ttf", 16, " MONOSPACE ,BOLD")
    MaxChar = Len(Formats$)
    ReDim Formats$(1 To MaxChar)

    ' If the user doesn't allow enough space on line for prompt and field,
    ' kick 'em out!
    If col + (Len(Prompt$) + Len(Formats$)) * sX > 80 * sX Then
        Ask$ = "NOT ENOUGH SPACE!"
        Exit Function
    End If

    Locate row, col
    Color PromptCol, PromptBk
    PRINTS Prompt$

    'PrintString col, row, Prompt$,PromptCol, PromptBk, 1

    VerLine$ = "|"
    Locate , , 1, 1, 8 ' Turn "block" cursor on.
    Length = 0
    Answer$ = ""
    FirstLine = CsrLin
    FirstPos = Pos(0) + Len(Prompt$) + 1

    Locate , FirstPos
    'Color EntryCol, FieldCol
    'For Formats = 1 To Len(Formats$)
    '      'IF MID$(Formats$, Formats, 1) = "@" OR MID$(Formats$, Formats, 1) = "#" OR MID$(Formats$, Length+1, 1) = "!" THEN
    '      If Mid$(Formats$, Formats, 1) = "@" Or Mid$(Formats$, Formats, 1) = "#" Or Mid$(Formats$, Formats, 1) = "!" Or Mid$(Formats$, Formats, 1) = "*" Then
    '            PRINTS " "
    '      Else
    '            PRINTS Mid$(Formats$, Formats, 1)
    '      End If
    'Next

    Locate , FirstPos
    Color EntryCol
    PRINTS VerLine$
    Locate , FirstPos

    Do
        If Length > MaxChar Then
            Locate , FirstPos
            PRINTS "                                  "
            Locate , FirstPos
            If Mid$(Formats$, 1, 1) <> "*" Then
                PRINTS Answer$
            Else
                PRINTS String$(Len(Answer$), "*")
            End If

            Exit Do
        End If
        If Mid$(Formats$, Length + 1, 1) <> "#" And Mid$(Formats$, Length + 1, 1) <> "@" And Mid$(Formats$, Length + 1, 1) <> "!" And Mid$(Formats$, Length + 1, 1) <> "*" Then
            Locate , FirstPos + Length
            Answer$ = Answer$ + Mid$(Formats$, Length + 1, 1)
            Length = Length + 1
            PRINTS Mid$(Formats$, Length, 1)
            PRINTS VerLine$
            If Length <= MaxChar Then Locate , FirstPos + Length
        End If


        Do
            KeyPress$ = InKey$
        Loop While KeyPress$ = ""

        Select Case KeyPress$
            Case Chr$(9)
                Locate , FirstPos + Length
                PRINTS "" ' Remove the
                Color PromptCol, PromptBk ' "imaginary" cursor.
                Ask$ = Answer$
                Timer On
                Exit Function
            Case Chr$(13)
                Locate , FirstPos
                PRINTS "                                  "
                Locate , FirstPos
                If Mid$(Formats$, 1, 1) <> "*" Then
                    PRINTS Answer$
                Else
                    PRINTS String$(Len(Answer$), "*")
                End If


                Color PromptCol, PromptBk ' "imaginary" cursor.
                Ask$ = Answer$
                Timer On
                Exit Function
            Case Chr$(BackSpace)
                Length = Length - 1 ' The user pressed
                If Length < 1 Then ' BACKSPACE, so lets
                    Answer$ = "" ' remove the last
                    Length = 0 ' letter from Answer$
                    Locate , FirstPos ' and reprint it.
                    PRINTS VerLine$ + "  "
                    Locate , FirstPos
                Else
                    If Mid$(Formats$, Length + 1, 1) = "@" Or Mid$(Formats$, Length + 1, 1) = "#" Or Mid$(Formats$, Length + 1, 1) = "!" Or Mid$(Formats$, Length + 1, 1) = "*" Then
                        Answer$ = Left$(Answer$, Len(Answer$) - 1)
                    Else
                        Answer$ = Left$(Answer$, Len(Answer$) - 2)
                        Length = Length - 1
                    End If


                    Locate , FirstPos + Length
                    PRINTS VerLine$ + "    "
                    'For Formats = 1 To Length + 3
                    '    If Mid$(Formats$, Formats, 1) = "@" Or Mid$(Formats$, Formats, 1) = "#" Or Mid$(Formats$, Length + 1, 1) = "!" Then
                    '        PRINTS " "
                    '    Else
                    '        PRINTS Mid$(Formats$, Formats, 1)
                    '    End If
                    'Next

                    'Locate , FirstPos
                    'PRINTS Answer$ + VerLine$
                    'Locate , FirstPos + Length
                End If
            Case Chr$(Esc)
                'jan 12, new use for ESC, quit proc,
                'instead of clear string
                'frustrating, how do I get this variable
                'to transfer to another module?
                EscPress = TRUE
                Timer On
                Exit Function
            Case Else
                t$ = Mid$(Formats$, Length + 1, 1)
                t% = Asc(KeyPress$)

                If (t$ = "@" And ((t% >= 33 And t% <= 47) Or (t% >= 58 And t% <= 126) Or t% = 32)) Or (t$ = "#" And t% >= 48 And t% <= 57) Or (t$ = "!" And t% <> 0) Then
                    Length = Length + 1
                    Answer$ = Answer$ + KeyPress$
                    Locate , FirstPos
                    PRINTS "                               "
                    Locate , FirstPos
                    PRINTS Answer$ + VerLine$
                    'PRINTS KeyPress$ + VerLine$

                    Locate , FirstPos + Length
                ElseIf (t$ = "*" And t% <> 0) Then
                    PRINTS "*" + VerLine$
                    Length = Length + 1
                    Answer$ = Answer$ + KeyPress$
                    Locate , FirstPos + Length

                Else

                    'Illegal Char
                    'Color BrWhite%, Blue%
                    'Answer$ = ""
                    'Locate FirstLine, FirstPos
                End If
        End Select
    Loop

    Locate , FirstPos + Length - 1
    PRINTS " " ' Remove the "imaginary" cursor.
    Color PromptCol, PromptBk
    Ask$ = Answer$
End Function

Sub PRINTS (Text$)
    row% = (CsrLin - 1) * fH 'finds current screen page text or font row height
    col% = (Pos(0) - 1) * fW 'finds current page text or font column width
    _PrintString (col%, row%), Text$
End Sub


Sub DrawWindow (x1%, y1%, x2%, y2%, Colour%)
    Line (x1%, y1%)-(x2%, y2%), Colour%, BF
End Sub

Sub Box (x1%, y1%, x2%, y2%, Colour%, Bk%)
    Line (x1%, y1%)-(x2%, y2%), Colour%, B
End Sub

Function ArSum (Ary() As String * 1, rstart%, rend%)
    Dim tmp As Double
    Dim s As String * 1
    For i = rstart% To rend%
        s = Ary(i)
        tmp = tmp + Asc(s)
    Next

    ArSum = tmp
End Function

Sub IllegalChar () ' typo corrected
    PCopy 0, 2
    Sound 100, 1
    '      Call DrawWindow(20 * sX, 10 * sY, 60 * sX, 14 * sY, Red%)
    setFont "inter.ttf", 25, 0, 1
    Call Titl(20 * sX, 10 * sY, 60 * sX, 14 * sY, BrWhite%, Red%, "Illegal Input", Yellow%, Red%)
    setFont "inter.ttf", 22, 0, 1
    PrintString 40 * sX, 12 * sY, "You have illegal Input!", BrWhite%, Red%, 1
    Color , Blue%
    P$ = Input$(1)
    PCopy 2, 0
End Sub

Function GetOpenFileName$ (Title$, InitialDir$, Filter$, FilterIndex, Flags&, hWnd&)

    Dim ofn As FILEDIALOGTYPE
    Dim szFile As String * 260

    ofn.lStructSize = Len(ofn)
    ofn.hwndOwner = Me.hWnd
    ofn.lpstrFile = _Offset(szFile)
    ofn.nMaxFile = Len(szFile)

    ofn.lpstrFilter = _Offset(Filter$)
    ofn.nFilterIndex = 1
    ofn.lpstrFileTitle = _Offset(Title$)
    ofn.nMaxFileTitle = 0
    ofn.lpstrInitialDir = _Offset(InitialDir$)
    ofn.flags = OFN_PATHMUSTEXIST Or OFN_FILEMUSTEXIST Or OFN_NOCHANGEDIR

    result = GetOpenFileNameA(ofn)
    If result Then
        'User selected a file, do something with it
        paths$ = RTrim$(Left$(szFile$, InStr(szFile$, Chr$(0)) - 1))

        For R = 1 To Len(paths$) ' Replace the pipes with character zero
            If Mid$(paths$, R, 1) = "\" Then Mid$(paths$, R, 1) = "/"
        Next R

        GetOpenFileName$ = paths$
    Else
        GetOpenFileName$ = ""
    End If
End Function

Function GetSaveFileName$ (Title$, InitialDir$, Filter$, FilterIndex, Flags&, hWnd&)

    Dim sfn As FILEDIALOGTYPE
    Dim szFile As String * 260

    lpstrDefExt$ = String$(10, 0) ' Extension will not be added when this is not specified

    sfn.lStructSize = Len(sfn)
    sfn.hwndOwner = hWnd&
    sfn.lpstrFilter = _Offset(fFilter$)
    sfn.nFilterIndex = FilterIndex
    sfn.lpstrFile = _Offset(szFile)
    sfn.nMaxFile = Len(szFile) - 1

    sfn.lpstrFileTitle = _Offset(Title$)
    sfn.nMaxFileTitle = 0
    sfn.lpstrInitialDir = _Offset(InitialDir$)
    sfn.lpstrTitle = _Offset(Title$)

    sfn.flags = Flags&

    result = GetSaveFileNameA&(sfn) ' Do dialog call!

    If result Then ' Trim the remaining zeros
        paths$ = RTrim$(Left$(szFile$, InStr(szFile$, Chr$(0)) - 1))
        For R = 1 To Len(paths$) ' Replace the pipes with character zero
            If Mid$(paths$, R, 1) = "\" Then Mid$(paths$, R, 1) = "/"
        Next R

        GetSaveFileName$ = paths$
    Else
        GetSaveFileName$ = ""
    End If

End Function


Function TTime$ ()

    'Convert system time to am/pm

    'The system time
    t$ = Time$

    'Get the hour
    Hr = Val(t$)

    'Check the hour
    If Hr < 12 Then Ampm$ = " AM" Else Ampm$ = " PM"
    If Hr > 12 Then Hr = Hr - 12

    'Return the hour plust the rest of the system date and the ending am/pm
    Tmp$ = Str$(Hr) + Right$(t$, 6) + Ampm$
    TTime$ = Tmp$

End Function

Function DDate$ ()

    'Convert date from digits to words

    Dim Month$(12)

    Restore Dates:
    For i = 1 To 12
        Read Month$(i)
    Next

    Tmp$ = Month$(Val(Left$(Date$, 2)))
    Tmp$ = Tmp$ + " " + Mid$(Date$, 4, 2)
    Tmp$ = Tmp$ + ", " + Right$(Date$, 4)
    DDate$ = Tmp$

End Function

Sub StatusLine ()

    ' Make sure the the timer doesn't get activated while we're
    ' displaying the status line, because it will produce an OUT OF DATA
    ' error in the DDate$ Function.
    Timer Stop


    ' Get the color and location of the cursor so we can restore it
    C = CsrLin
    P = Pos(0)
    'If P - 1 > 0 Then
    '    col = Screen(C, P - 1, 1)
    'ElseIf C > 1 Then
    '    col = Screen(C - 1, P, 1)
    'End If

    If C > 1 Then
        col = Screen(C - 1, P, 1)
    ElseIf P > 1 Then
        col = Screen(C, P - 1, 1)
    End If

    'Locate Int(25 * scY), Int(70 * scX)
    Locate 1, Int(70 * scX)

    Color BrGreen%, Black%
    Print DDate$; "  ";

    Color BrGreen%, Black%
    Print LTrim$(TTime$);

    Locate C, P
    Color col \ 16, col Mod 16

    Timer On

End Sub

Sub Rotates (x1, y1, x2, y2, FG, BG, orgX, orgY)
    Line (y1 - orgY + orgX, orgX + orgY - x1)-(y2 - orgY + orgX, orgX + orgY - x2), FG, BF
End Sub

Sub TextSave
    Timer Stop
    Out &H3C8, 1: Out &H3C9, 0: Out &H3C9, 0: Out &H3C9, 0 'print text as background color
    Color 1 'hide the character printing
    For ascii% = 0 To 255 'Draw map of each character
        _PrintString (0, 0), Chr$(ascii%) 'PRINT ASCII characters to top left corner
        For row% = 0 To 15 'read 16 row byte values
            byte = 0 'reset value every row
            For col% = 7 To 0 Step -1 'read 8 pixels from right to left
                byte = byte * 2 - (Point(col%, row%) > 0) 'bit-packing with 2 ^ bit
            Next
            Char(ascii%, row%) = Chr$(byte) 'convert row byte value to ASCII character
        Next
    Next
    Timer On
    Palette 'restore all palette colors
End Sub

Sub PrintString (x, y, text$, textColor, backColor, align)

    Color textColor, backColor
    Select Case align
        Case 0 'align to left
            _PrintString (x, y), text$
        Case 1 'align to center
            _PrintString (x - Len(text$) * fW / 2, y), text$
        Case 2 'align to right
            _PrintString (x - Len(text$) * fW, y), text$
    End Select

End Sub

Sub setFont (family$, fontSize%, isItalic%, isBold%)
    style$ = " MONOSPACE"
    'If italic% = 1 Then style$ = style$ + ", ITALIC"
    'If Bold% = 1 Then style$ = style$ + ", BOLD"
    If isBold% = 1 Then
        family$ = family$ + "-Medium.ttf"
    Else
        family$ = family$ + "-Light.ttf"
    End If
    ft& = _LoadFont("font\" + family$, fontSize%)

    If ft& < 0 Then
        ft& = _LoadFont(Environ$("SYSTEMROOT") + "\fonts\" + family$, fontSize%)
    Else
        _Font ft&
    End If
    fH = _FontHeight: fW = _PrintWidth("W") * 0.6
End Sub
