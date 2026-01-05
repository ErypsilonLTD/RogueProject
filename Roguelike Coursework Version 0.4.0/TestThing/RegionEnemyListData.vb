Imports System.IO

Public Class RegionEnemyListData
    Public ListType
    Public ListRegion

    Public ListSize As Byte
    Public EnemiesList As EnemyData() = Array.Empty(Of EnemyData)()
End Class

Public Class FullEnemyListData
    Public BasicEnemiesList(0) As RegionEnemyListData
    Public AdvancedEnemiesList(0) As RegionEnemyListData
    Public BossEnemiesList(0) As RegionEnemyListData
    Public ReadOnly Path As String = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "EnemySave.txt")

    Public Loaded As Boolean = FillLists()

    Public Function FillLists()
        'Name Size Rules: Type <= 11 Weapon <= 12 Fun Fact <= 46

        Dim temp As String() = {0}
        If File.Exists(Path) = True Then
            temp = Split(File.ReadAllText(Path), vbCrLf)

        End If

#Region "Goblin Lists"
#Region "Basic Goblin List"

        Dim BasicGoblinList As New RegionEnemyListData With {
         .ListType = "Basic", .ListRegion = "Goblin",
         .ListSize = 4
        }
        ReDim BasicGoblinList.EnemiesList(BasicGoblinList.ListSize - 1)
        Dim GoblinMiscreant As New EnemyData With {
                 .HealthRange = {7, 12},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.33, .CoinYield = 7,
                 .EnemyType = "Miscreant",
                 .WeaponType = "Shiv", .DamageRange = {1, 5}, .HitChance = {3, 9}, .CritAddative = 1,
                 .FunFact = "Thieving Bastards"
        }
        AddNewEnemy(GoblinMiscreant, BasicGoblinList.EnemiesList)
        Dim GoblinVagabond As New EnemyData With {
                 .HealthRange = {4, 5},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 0.75, .CoinYield = 0,
                 .EnemyType = "Vagabond",
                 .WeaponType = "Fists", .DamageRange = {1, 3}, .HitChance = {3, 7}, .CritAddative = 1,
                 .FunFact = "Really Doesn't Deserve Killing"
        }
        AddNewEnemy(GoblinVagabond, BasicGoblinList.EnemiesList)
        Dim GoblinMerchant As New EnemyData With {
                 .HealthRange = {6, 10},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1, .CoinYield = 25,
                 .EnemyType = "Merchant",
                 .WeaponType = "Dagger", .DamageRange = {2, 5}, .HitChance = {4, 8}, .CritAddative = 2,
                 .FunFact = "Doesn't Actually Have A Job"
        }
        AddNewEnemy(GoblinMerchant, BasicGoblinList.EnemiesList)
        Dim GoblinSquire As New EnemyData With {
                 .HealthRange = {7, 12},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.75, .CoinYield = 2,
                 .EnemyType = "Squire",
                 .WeaponType = "Broken Sword", .DamageRange = {1, 4}, .HitChance = {3, 8}, .CritAddative = 5,
                 .FunFact = "Secretly Wants To Kill Their Knight"
        }
        AddNewEnemy(GoblinSquire, BasicGoblinList.EnemiesList)
        AddNewList(BasicGoblinList, BasicEnemiesList)
#End Region

#Region "Advanced Goblin List"
        Dim AdvancedGoblinList As New RegionEnemyListData With {
                 .ListType = "Advanced", .ListRegion = "Goblin",
                 .ListSize = 3
                }
        ReDim AdvancedGoblinList.EnemiesList(AdvancedGoblinList.ListSize - 1)
        Dim GoblinKnight As New EnemyData With {
                 .HealthRange = {10, 15},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2, .CoinYield = 9,
                 .EnemyType = "Knight",
                 .WeaponType = "Broad Sword", .DamageRange = {3, 6}, .HitChance = {4, 8}, .CritAddative = 3,
                 .FunFact = "Never Actually Fought Before"
        }
        AddNewEnemy(GoblinKnight, AdvancedGoblinList.EnemiesList)
        Dim GoblinCivilGuard As New EnemyData With {
                 .HealthRange = {9, 16},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.75, .CoinYield = 7,
                 .EnemyType = "Civil Guard",
                 .WeaponType = "Arming Sword", .DamageRange = {3, 5}, .HitChance = {3, 8}, .CritAddative = 2,
                 .FunFact = "Knows The Empress On A Middle Name Basis"
        }
        AddNewEnemy(GoblinCivilGuard, AdvancedGoblinList.EnemiesList)
        Dim GoblinBlacksmith As New EnemyData With {
                 .HealthRange = {8, 14},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2, .CoinYield = 8,
                 .EnemyType = "Blacksmith",
                 .WeaponType = "Fresh Sword", .DamageRange = {4, 5}, .HitChance = {4, 9}, .CritAddative = 2,
                 .FunFact = "Better Fighter Than The Knight, Experience Kills"
        }
        AddNewEnemy(GoblinBlacksmith, AdvancedGoblinList.EnemiesList)
        AddNewList(AdvancedGoblinList, AdvancedEnemiesList)
#End Region

#Region "Boss Goblin List"
        Dim BossGoblinList As New RegionEnemyListData With {
                 .ListType = "Boss", .ListRegion = "Goblin",
                 .ListSize = 1
                }
        ReDim BossGoblinList.EnemiesList(BossGoblinList.ListSize - 1)
        Dim GoblinEmpress As New EnemyData With {
                 .HealthRange = {20, 20},
                 .Armour = 2, .Defeated = Load(temp),
                 .XPYield = 75, .CoinYield = 60,
                 .EnemyType = "Empress",
                 .WeaponType = "Rapier", .DamageRange = {3, 6}, .HitChance = {4, 9}, .CritAddative = 3,
                 .FunFact = "Crown Matriarch Of All Goblins"
        }
        AddNewEnemy(GoblinEmpress, BossGoblinList.EnemiesList)
        AddNewList(BossGoblinList, BossEnemiesList)
#End Region
#End Region

#Region "Human Lists"
#Region "Basic Human List"
        Dim BasicHumanList As New RegionEnemyListData With {
         .ListType = "Basic", .ListRegion = "Human",
         .ListSize = 7
        }
        ReDim BasicHumanList.EnemiesList(BasicHumanList.ListSize - 1)
        Dim HumanTraveller As New EnemyData With {
                 .HealthRange = {9, 14},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.75, .CoinYield = 3,
                 .EnemyType = "Traveller",
                 .WeaponType = "Frankish Axe", .DamageRange = {3, 5}, .HitChance = {4, 8}, .CritAddative = 2,
                 .FunFact = "Spent All His Coin At The Local Tavern"
        }
        AddNewEnemy(HumanTraveller, BasicHumanList.EnemiesList)
        Dim HumanButcher As New EnemyData With {
                 .HealthRange = {8, 13},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.5, .CoinYield = 10,
                 .EnemyType = "Butcher",
                 .WeaponType = "Cleaver", .DamageRange = {2, 4}, .HitChance = {2, 9}, .CritAddative = 7,
                 .FunFact = "Terrible Fighter, Gambles On Lucky Strikes"
        }
        AddNewEnemy(HumanButcher, BasicHumanList.EnemiesList)
        Dim HumanScholar As New EnemyData With {
                 .HealthRange = {6, 16},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.9, .CoinYield = 12,
                 .EnemyType = "Scholar",
                 .WeaponType = "Sceptre", .DamageRange = {1, 6}, .HitChance = {2, 10}, .CritAddative = 3,
                 .FunFact = "Anything Goes When You're Intelligent"
        }
        AddNewEnemy(HumanScholar, BasicHumanList.EnemiesList)
        Dim HumanBard As New EnemyData With {
                 .HealthRange = {7, 12},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.3, .CoinYield = 18,
                 .EnemyType = "Bard",
                 .WeaponType = "Guitar", .DamageRange = {1, 3}, .HitChance = {3, 8}, .CritAddative = 1,
                 .FunFact = "A Waste Of Space On Any Adventuring Team"
        }
        AddNewEnemy(HumanBard, BasicHumanList.EnemiesList)
        Dim HumanBanker As New EnemyData With {
                 .HealthRange = {6, 10},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 1.2, .CoinYield = 32,
                 .EnemyType = "Banker",
                 .WeaponType = "Knife", .DamageRange = {1, 3}, .HitChance = {4, 8}, .CritAddative = 2,
                 .FunFact = "Anything Goes When You're Intelligent"
        }
        AddNewEnemy(HumanBanker, BasicHumanList.EnemiesList)
        Dim HumanSpearLevie As New EnemyData With {
                 .HealthRange = {11, 15},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2, .CoinYield = 2,
                 .EnemyType = "Levie",
                 .WeaponType = "Spear", .DamageRange = {3, 4}, .HitChance = {4, 8}, .CritAddative = 3,
                 .FunFact = "Why Are Levies Raised If There Is No War?"
        }
        AddNewEnemy(HumanSpearLevie, BasicHumanList.EnemiesList)
        Dim HumanScimitarLevie As New EnemyData With {
                 .HealthRange = {11, 16},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2.2, .CoinYield = 2,
                 .EnemyType = "Levie",
                 .WeaponType = "Scimitar", .DamageRange = {3, 6}, .HitChance = {4, 8}, .CritAddative = 2,
                 .FunFact = "Why Are Levies Raised If There Is No War?"
        }
        AddNewEnemy(HumanScimitarLevie, BasicHumanList.EnemiesList)
        AddNewList(BasicHumanList, BasicEnemiesList)
#End Region

#Region "Advanced Human List"
        Dim AdvancedHumanList As New RegionEnemyListData With {
                 .ListType = "Advanced", .ListRegion = "Human",
                 .ListSize = 4
                }
        ReDim AdvancedHumanList.EnemiesList(AdvancedHumanList.ListSize - 1)
        Dim HumanPaladin As New EnemyData With {
                 .HealthRange = {15, 19},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2.4, .CoinYield = 21,
                 .EnemyType = "Paladin",
                 .WeaponType = "Greatsword", .DamageRange = {3, 6}, .HitChance = {4, 8}, .CritAddative = 3,
                 .FunFact = "Fights Piously"
        }
        AddNewEnemy(HumanPaladin, AdvancedHumanList.EnemiesList)
        Dim HumanCleric As New EnemyData With {
                 .HealthRange = {14, 17},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2.25, .CoinYield = 16,
                 .EnemyType = "Cleric",
                 .WeaponType = "Staff", .DamageRange = {4, 5}, .HitChance = {4, 8}, .CritAddative = 2,
                 .FunFact = "A Symbol Of Faith On The Battlefield"
        }
        AddNewEnemy(HumanCleric, AdvancedHumanList.EnemiesList)
        Dim HumanCaster As New EnemyData With {
                 .HealthRange = {11, 13},
                 .Armour = 0, .Defeated = Load(temp),
                 .XPYield = 2.1, .CoinYield = 12,
                 .EnemyType = "Caster",
                 .WeaponType = "Spellbook", .DamageRange = {1, 6}, .HitChance = {1, 11}, .CritAddative = 12,
                 .FunFact = "Chancy With Her Spells"
        }
        AddNewEnemy(HumanCaster, AdvancedHumanList.EnemiesList)
        Dim HumanRoyalGuard As New EnemyData With {
                 .HealthRange = {15, 19},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 2.5, .CoinYield = 24,
                 .EnemyType = "Royal Guard",
                 .WeaponType = "Musket", .DamageRange = {4, 7}, .HitChance = {4, 8}, .CritAddative = 2,
                 .FunFact = "Proof Of Human Advancement"
        }
        AddNewEnemy(HumanRoyalGuard, AdvancedHumanList.EnemiesList)
        AddNewList(AdvancedHumanList, AdvancedEnemiesList)
#End Region

#Region "Boss Human List"
        Dim BossHumanList As New RegionEnemyListData With {
                 .ListType = "Boss", .ListRegion = "Champion Of",
                 .ListSize = 3
                }
        ReDim BossHumanList.EnemiesList(BossHumanList.ListSize - 1)
        Dim HumanChampionChance As New EnemyData With {
                 .HealthRange = {25, 25},
                 .Armour = 1, .Defeated = Load(temp),
                 .XPYield = 100, .CoinYield = 100,
                 .EnemyType = "Chance",
                 .WeaponType = "Coin", .DamageRange = {0, 0}, .HitChance = {5, 10}, .CritAddative = 20,
                 .FunFact = "Human Champion Of Chance"
        }
        AddNewEnemy(HumanChampionChance, BossHumanList.EnemiesList)
        Dim HumanChampionPiety As New EnemyData With {
                 .HealthRange = {30, 30},
                 .Armour = 2, .Defeated = Load(temp),
                 .XPYield = 200, .CoinYield = 100,
                 .EnemyType = "Piety",
                 .WeaponType = "Staff", .DamageRange = {5, 7}, .HitChance = {4, 9}, .CritAddative = 3,
                 .FunFact = "Human Champion Of Piety"
        }
        AddNewEnemy(HumanChampionPiety, BossHumanList.EnemiesList)
        Dim HumanChampionWar As New EnemyData With {
                 .HealthRange = {40, 40},
                 .Armour = 2, .Defeated = Load(temp),
                 .XPYield = 300, .CoinYield = 100,
                 .EnemyType = "War",
                 .WeaponType = "Greatsword", .DamageRange = {10, 12}, .HitChance = {4, 9}, .CritAddative = 4,
                 .FunFact = "Human Champion Of War"
        }
        AddNewEnemy(HumanChampionWar, BossHumanList.EnemiesList)
        AddNewList(BossHumanList, BossEnemiesList)
#End Region

#End Region

        Return True
    End Function

    Private Shared Sub AddNewEnemy(ByVal Enemy As EnemyData, ByRef List As EnemyData())
        Dim Temp As Byte = 0
        Do
            If List(Temp) Is Nothing Then
                List(Temp) = Enemy
                Return
            End If
            Temp += 1
        Loop
    End Sub

    Private Shared Sub AddNewList(ByVal Region As RegionEnemyListData, ByRef List As RegionEnemyListData())
        Dim Temp As Byte = 0
        If List(List.Length - 1) IsNot Nothing Then ReDim Preserve List(List.Length)
        Do
            If List(Temp) Is Nothing Then
                List(Temp) = Region
                Return
            End If
            Temp += 1
        Loop
    End Sub

    Private Function Load(ByVal List As String()) As Int16
        For Index = 0 To List.Length - 1
            If List(Index) = "Skip" Then

            ElseIf Index > List.Length Then
                ReDim List(List.Length)
            Else
                Dim temp As Int16
                temp = Val(List(Index))
                List(Index) = "Skip"
                Return temp
            End If
        Next
        Return 0
    End Function


    Public Sub EnemyCompendium()
        Do
            Call DrawScreen("MainMenu")
            Console.Write(PrintToScreen("Enemy Compedium:", 2, 1))
            Console.Write(PrintToScreen("Enter Region:  ", 2, 3))
            Console.Write(PrintToScreen("X To Return", 2, 14))

            Dim Region As Byte = 10
            Dim Response As String

            Do
                Response = TakeInputs("Any")
                If Response IsNot Nothing Then
                    If Response = "X" Then
                        Return
                    ElseIf Val(Response) < Me.BasicEnemiesList.Length + 1 AndAlso Val(Response) > 0 Then
                        Region = Response - 1
                    Else
                        Call DisplayErrorMessage("Too Low/High!")
                    End If

                End If
            Loop Until Region <> 10

            Console.Write(PrintToScreen(Region + 1, 16, 3))

            Dim List As String() = {"Basic Enemy List:", "Advanced Enemy List:", "Boss Enemy List:"}
            Console.Write(PrintToScreen(List(0), 3, 4))
            Console.Write(PrintToScreen(List(1), 3, 5))
            Console.Write(PrintToScreen(List(2), 3, 6))
            Console.Write(PrintToScreen("X To Return, E To Select", 2, 14))
            Console.Write(PrintToScreen("[↕]", 63, 14))

            Dim Pos As Byte() = {3, 4}

            Do
                Console.ForegroundColor = 13
                Console.Write(PrintToScreen(List(Pos(1) - 4), Pos(0), Pos(1)))

                Console.ForegroundColor = 15
                Response = TakeInputs("Any")
                Console.CursorVisible = False

                If Response = "S" AndAlso Pos(1) < 6 Then
                    Console.ForegroundColor = 15
                    Console.Write(PrintToScreen(List(Pos(1) - 4), Pos(0), Pos(1)))
                    Pos(1) += 1
                ElseIf Response = "W" AndAlso Pos(1) > 4 Then
                    Console.ForegroundColor = 15
                    Console.Write(PrintToScreen(List(Pos(1) - 4), Pos(0), Pos(1)))
                    Pos(1) -= 1
                ElseIf Response = "X" Then
                    Exit Do
                ElseIf Response = "E" Then
                    Select Case Pos(1)
                        Case 4
                            Call ShowEnemies(Me.BasicEnemiesList(Region))
                        Case 5
                            Call ShowEnemies(Me.AdvancedEnemiesList(Region))
                        Case 6
                            Call ShowEnemies(Me.BossEnemiesList(Region))
                    End Select
                    Exit Do
                End If
            Loop
        Loop
    End Sub

    Private Shared Sub ShowEnemies(ByVal List As RegionEnemyListData)
        Dim Pos As SByte = 0
        Do
            Call DrawScreen("MainMenu")
            Console.Write(PrintToScreen("Enemy Compendium: " & List.ListRegion & " " & List.EnemiesList(Pos).EnemyType & " [" & Pos + 1 & "/" & List.EnemiesList.Length & "]", 2, 1))
            Console.Write(PrintToScreen("X To Return", 55, 1))

            Console.Write(PrintToScreen("Stats:", 2, 3))
            Console.Write(PrintToScreen("Health: " & List.EnemiesList(Pos).HealthRange(0) & "/" & List.EnemiesList(Pos).HealthRange(1), 3, 4))
            Console.Write(PrintToScreen("Damage: " & List.EnemiesList(Pos).DamageRange(0) & "/" & List.EnemiesList(Pos).DamageRange(1), 3, 5))
            Console.Write(PrintToScreen("Armour: " & List.EnemiesList(Pos).Armour, 3, 6))
            Console.Write(PrintToScreen("Xp Yield (Base): " & List.EnemiesList(Pos).XPYield, 3, 8))
            Console.Write(PrintToScreen("Coin Yield (Base): " & List.EnemiesList(Pos).CoinYield, 3, 9))
            Console.Write(PrintToScreen("Defeated: " & List.EnemiesList(Pos).Defeated, 3, 10))
            Console.Write(PrintToScreen("Weapon: " & List.EnemiesList(Pos).WeaponType, 3, 11))
            Console.Write(PrintToScreen("Crit Addative: " & List.EnemiesList(Pos).CritAddative, 3, 12))

            Console.Write(PrintToScreen("Hit Chance Is Calculated By A Range", 28, 3))
            Console.Write(PrintToScreen("Crits Add The Crit Addative To Damage", 28, 4))
            Console.Write(PrintToScreen("Anything Below 5 Misses", 28, 5))
            Console.Write(PrintToScreen("Anything Above 7 Crits", 28, 6))

            Console.Write(PrintToScreen(List.EnemiesList(Pos).EnemyType & " Hit Chance:", 28, 8))
            Console.Write(PrintToScreen("Full Range:  " & List.EnemiesList(Pos).HitChance(0) & "/" & List.EnemiesList(Pos).HitChance(1), 29, 9))
            Dim Range As Byte = 1 + List.EnemiesList(Pos).HitChance(1) - List.EnemiesList(Pos).HitChance(0)
            Console.Write(PrintToScreen("Hit Chance:  " & 3 & "/" & Range, 29, 10))
            Console.Write(PrintToScreen("Crit Chance: " & List.EnemiesList(Pos).HitChance(1) - 7 & "/" & Range, 29, 11))
            Console.Write(PrintToScreen("Miss Chance: " & 5 - List.EnemiesList(Pos).HitChance(0) & "/" & Range, 29, 12))

            Console.Write(PrintToScreen("Analysis: " & List.EnemiesList(Pos).FunFact, 2, 14))
            Console.Write(PrintToScreen("[↔]", 63, 14))

            Dim Response As String = TakeInputs("Str")

            If Response = "D" AndAlso Pos < List.EnemiesList.Length Then
                Pos += 1
                If Pos = List.EnemiesList.Length Then Pos = 0
            ElseIf Response = "A" AndAlso Pos > -1 Then
                Pos -= 1
                If Pos = -1 Then Pos = List.EnemiesList.Length - 1
            ElseIf Response = "X" Then
                Return
            End If
        Loop
    End Sub


End Class