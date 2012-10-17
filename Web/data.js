var statistics = new Statistics(39626);

statistics.addStatistics(
    "Melee vs. ranged composition",
    [
        ["Melee: 0, Ranged: 5", 633, 0.5529226],
        ["Melee: 1, Ranged: 4", 5586, 0.5179019],
        ["Melee: 2, Ranged: 3", 14451, 0.5052245],
        ["Melee: 3, Ranged: 2", 13763, 0.5001817],
        ["Melee: 4, Ranged: 1", 4679, 0.4629194],
        ["Melee: 5, Ranged: 0", 514, 0.42607],
    ]
);

statistics.addStatistics(
    "Hero attribute type composition",
    [
        ["Strength: 4, Agility: 0, Intelligence: 1", 288, 0.5416667],
        ["Strength: 3, Agility: 0, Intelligence: 2", 981, 0.5351682],
        ["Strength: 2, Agility: 0, Intelligence: 3", 988, 0.5293522],
        ["Strength: 2, Agility: 1, Intelligence: 2", 5644, 0.5272856],
        ["Strength: 1, Agility: 1, Intelligence: 3", 3552, 0.5242117],
        ["Strength: 1, Agility: 0, Intelligence: 4", 313, 0.5239617],
        ["Strength: 0, Agility: 1, Intelligence: 4", 491, 0.5071283],
        ["Strength: 1, Agility: 2, Intelligence: 2", 6858, 0.5059784],
        ["Strength: 3, Agility: 1, Intelligence: 1", 2632, 0.4973404],
        ["Strength: 4, Agility: 1, Intelligence: 0", 358, 0.4972067],
        ["Strength: 2, Agility: 2, Intelligence: 1", 5898, 0.4911835],
        ["Strength: 0, Agility: 2, Intelligence: 3", 1538, 0.4895969],
        ["Strength: 0, Agility: 3, Intelligence: 2", 1646, 0.4854192],
        ["Strength: 3, Agility: 2, Intelligence: 0", 1166, 0.483705],
        ["Strength: 1, Agility: 3, Intelligence: 1", 4005, 0.4808989],
        ["Strength: 2, Agility: 3, Intelligence: 0", 1515, 0.4778878],
        ["Strength: 0, Agility: 4, Intelligence: 1", 764, 0.4306283],
        ["Strength: 1, Agility: 4, Intelligence: 0", 796, 0.4095477],
        ["Strength: 0, Agility: 5, Intelligence: 0", 146, 0.3630137],
    ]
);

statistics.addStatistics(
    "Optimal number of carries per team",
    [
        ["Carry: 0", 156, 0.6410257],
        ["Carry: 1", 2954, 0.5754908],
        ["Carry: 2", 12144, 0.5413373],
        ["Carry: 3", 15166, 0.4920216],
        ["Carry: 4", 7684, 0.4419573],
        ["Carry: 5", 1522, 0.3817345],
    ]
);

statistics.addStatistics(
    "Optimal number of disablers per team",
    [
        ["Disabler: 5", 509, 0.5225933],
        ["Disabler: 4", 4224, 0.5196496],
        ["Disabler: 3", 11712, 0.510929],
        ["Disabler: 2", 14112, 0.4997166],
        ["Disabler: 1", 7539, 0.4833532],
        ["Disabler: 0", 1530, 0.4392157],
    ]
);

statistics.addStatistics(
    "Optimal number of durable heroes per team",
    [
        ["Durable: 5", 70, 0.6142857],
        ["Durable: 4", 1060, 0.5603774],
        ["Durable: 3", 6141, 0.5337893],
        ["Durable: 2", 13983, 0.5111921],
        ["Durable: 1", 14094, 0.4859515],
        ["Durable: 0", 4278, 0.4443665],
    ]
);

statistics.addStatistics(
    "Optimal number heroes with escapes per team",
    [
        ["Escape: 0", 6331, 0.5765282],
        ["Escape: 1", 14965, 0.5238222],
        ["Escape: 2", 12741, 0.468723],
        ["Escape: 3", 4815, 0.427622],
        ["Escape: 4", 731, 0.374829],
    ]
);

statistics.addStatistics(
    "Optimal number of initiators per team",
    [
        ["Initiator: 5", 84, 0.6190476],
        ["Initiator: 4", 1111, 0.5040504],
        ["Initiator: 2", 13160, 0.5033435],
        ["Initiator: 1", 14015, 0.5009633],
        ["Initiator: 3", 5692, 0.5005271],
        ["Initiator: 0", 5564, 0.4865205],
    ]
);

statistics.addStatistics(
    "Optimal number of junglers per team",
    [
        ["Jungler: 3", 237, 0.556962],
        ["Jungler: 2", 3001, 0.5198267],
        ["Jungler: 0", 20869, 0.4983948],
        ["Jungler: 1", 15513, 0.4974537],
    ]
);

statistics.addStatistics(
    "Optimal number of lane supports per team",
    [
        ["LaneSupport: 3", 125, 0.576],
        ["LaneSupport: 2", 2238, 0.5634495],
        ["LaneSupport: 1", 13695, 0.5300475],
        ["LaneSupport: 0", 23565, 0.4760874],
    ]
);

statistics.addStatistics(
    "Optimal number of nukers per team",
    [
        ["Nuker: 4", 1470, 0.5142857],
        ["Nuker: 3", 7176, 0.5133779],
        ["Nuker: 2", 14053, 0.5009606],
        ["Nuker: 1", 12647, 0.4946628],
        ["Nuker: 0", 4160, 0.4853365],
        ["Nuker: 5", 120, 0.4833333],
    ]
);

statistics.addStatistics(
    "Optimal number of pushers per team",
    [
        ["Pusher: 4", 320, 0.61875],
        ["Pusher: 3", 2594, 0.5531997],
        ["Pusher: 2", 9365, 0.5219434],
        ["Pusher: 1", 16428, 0.4984782],
        ["Pusher: 0", 10896, 0.4665932],
    ]
);

statistics.addStatistics(
    "Optimal number of supports per team",
    [
        ["Support: 4", 240, 0.5666667],
        ["Support: 3", 2685, 0.5303538],
        ["Support: 2", 11457, 0.5191586],
        ["Support: 1", 17106, 0.4974863],
        ["Support: 0", 8132, 0.465937],
    ]
);

statistics.addStatistics(
    "Optimal number of carries and disablers per team",
    [
        ["Carry: 0, Disabler: 4", 61, 0.7213115],
        ["Carry: 1, Disabler: 1", 128, 0.640625],
        ["Carry: 1, Disabler: 2", 534, 0.6123595],
        ["Carry: 1, Disabler: 3", 1202, 0.5757071],
        ["Carry: 2, Disabler: 1", 1129, 0.5651019],
        ["Carry: 2, Disabler: 2", 3835, 0.5561929],
        ["Carry: 1, Disabler: 4", 898, 0.5489978],
        ["Carry: 1, Disabler: 5", 183, 0.5464481],
        ["Carry: 2, Disabler: 3", 4922, 0.533523],
        ["Carry: 2, Disabler: 4", 1938, 0.5232198],
        ["Carry: 2, Disabler: 5", 213, 0.5211267],
        ["Carry: 3, Disabler: 0", 418, 0.5143541],
        ["Carry: 3, Disabler: 1", 3045, 0.5057471],
        ["Carry: 3, Disabler: 4", 1104, 0.495471],
        ["Carry: 3, Disabler: 3", 4260, 0.4884976],
        ["Carry: 2, Disabler: 0", 107, 0.4859813],
        ["Carry: 3, Disabler: 2", 6256, 0.4857737],
        ["Carry: 3, Disabler: 5", 83, 0.4819277],
        ["Carry: 4, Disabler: 2", 3054, 0.4521939],
        ["Carry: 4, Disabler: 3", 1175, 0.4382979],
        ["Carry: 4, Disabler: 1", 2599, 0.4351674],
        ["Carry: 4, Disabler: 4", 203, 0.4334975],
        ["Carry: 4, Disabler: 0", 646, 0.4334365],
        ["Carry: 5, Disabler: 1", 634, 0.3958991],
        ["Carry: 5, Disabler: 2", 414, 0.3913043],
        ["Carry: 5, Disabler: 3", 104, 0.3846154],
        ["Carry: 5, Disabler: 0", 350, 0.34],
    ]
);

statistics.addStatistics(
    "Optimal number of carries and initiators per team",
    [
        ["Carry: 0, Initiator: 2", 60, 0.7833334],
        ["Carry: 1, Initiator: 0", 180, 0.5944445],
        ["Carry: 1, Initiator: 1", 828, 0.5845411],
        ["Carry: 1, Initiator: 3", 642, 0.5732087],
        ["Carry: 1, Initiator: 2", 1139, 0.5689201],
        ["Carry: 1, Initiator: 4", 148, 0.5675676],
        ["Carry: 2, Initiator: 1", 4034, 0.557759],
        ["Carry: 2, Initiator: 0", 1305, 0.5448276],
        ["Carry: 2, Initiator: 2", 4269, 0.5343172],
        ["Carry: 2, Initiator: 3", 2038, 0.5255152],
        ["Carry: 2, Initiator: 4", 464, 0.5150862],
        ["Carry: 3, Initiator: 2", 5008, 0.4960064],
        ["Carry: 3, Initiator: 1", 5489, 0.4926216],
        ["Carry: 3, Initiator: 4", 370, 0.4891892],
        ["Carry: 3, Initiator: 3", 2046, 0.4872923],
        ["Carry: 3, Initiator: 0", 2223, 0.4849303],
        ["Carry: 4, Initiator: 1", 2994, 0.4472278],
        ["Carry: 4, Initiator: 0", 1497, 0.4428858],
        ["Carry: 4, Initiator: 2", 2281, 0.4388426],
        ["Carry: 4, Initiator: 3", 801, 0.4307116],
        ["Carry: 4, Initiator: 4", 110, 0.4272727],
        ["Carry: 5, Initiator: 0", 353, 0.4135977],
        ["Carry: 5, Initiator: 2", 403, 0.4044665],
        ["Carry: 5, Initiator: 1", 638, 0.3573668],
        ["Carry: 5, Initiator: 3", 116, 0.3189655],
    ]
);

statistics.addStatistics(
    "Optimal number of carries and lane supports per team",
    [
        ["Carry: 0, LaneSupport: 0", 59, 0.6610169],
        ["Carry: 0, LaneSupport: 1", 71, 0.6338028],
        ["Carry: 1, LaneSupport: 1", 1270, 0.5905512],
        ["Carry: 2, LaneSupport: 2", 1151, 0.5786273],
        ["Carry: 1, LaneSupport: 2", 405, 0.5654321],
        ["Carry: 1, LaneSupport: 0", 1231, 0.5629569],
        ["Carry: 2, LaneSupport: 1", 5015, 0.5515454],
        ["Carry: 2, LaneSupport: 3", 75, 0.5466667],
        ["Carry: 3, LaneSupport: 2", 661, 0.537065],
        ["Carry: 2, LaneSupport: 0", 5903, 0.5253261],
        ["Carry: 3, LaneSupport: 1", 5521, 0.5115016],
        ["Carry: 4, LaneSupport: 1", 1818, 0.4807481],
        ["Carry: 3, LaneSupport: 0", 8984, 0.4767364],
        ["Carry: 4, LaneSupport: 0", 5866, 0.4299352],
        ["Carry: 5, LaneSupport: 0", 1522, 0.3817345],
    ]
);

statistics.addStatistics(
    "Optimal number of carries, disablers and initiators per team",
    [
        ["Carry: 1, Disabler: 2, Initiator: 1", 172, 0.627907],
        ["Carry: 1, Disabler: 1, Initiator: 2", 59, 0.6271186],
        ["Carry: 1, Disabler: 2, Initiator: 2", 204, 0.6127451],
        ["Carry: 1, Disabler: 5, Initiator: 2", 55, 0.6],
        ["Carry: 1, Disabler: 2, Initiator: 3", 102, 0.5882353],
        ["Carry: 1, Disabler: 1, Initiator: 1", 51, 0.5882353],
        ["Carry: 1, Disabler: 3, Initiator: 3", 262, 0.5877863],
        ["Carry: 1, Disabler: 3, Initiator: 1", 322, 0.5869565],
        ["Carry: 2, Disabler: 1, Initiator: 1", 427, 0.5807962],
        ["Carry: 1, Disabler: 3, Initiator: 0", 88, 0.5795454],
        ["Carry: 2, Disabler: 1, Initiator: 2", 349, 0.5787966],
        ["Carry: 1, Disabler: 3, Initiator: 4", 54, 0.5740741],
        ["Carry: 2, Disabler: 2, Initiator: 0", 492, 0.5691057],
        ["Carry: 1, Disabler: 3, Initiator: 2", 469, 0.5628998],
        ["Carry: 2, Disabler: 2, Initiator: 1", 1440, 0.5625],
        ["Carry: 2, Disabler: 3, Initiator: 1", 1600, 0.559375],
        ["Carry: 1, Disabler: 4, Initiator: 3", 200, 0.555],
        ["Carry: 2, Disabler: 2, Initiator: 4", 101, 0.5544555],
        ["Carry: 2, Disabler: 1, Initiator: 3", 116, 0.5517241],
        ["Carry: 1, Disabler: 4, Initiator: 1", 245, 0.5510204],
        ["Carry: 2, Disabler: 2, Initiator: 3", 525, 0.5485714],
        ["Carry: 2, Disabler: 4, Initiator: 0", 119, 0.5462185],
        ["Carry: 2, Disabler: 2, Initiator: 2", 1270, 0.5456693],
        ["Carry: 3, Disabler: 0, Initiator: 1", 190, 0.5421053],
        ["Carry: 1, Disabler: 4, Initiator: 2", 350, 0.5371429],
        ["Carry: 2, Disabler: 4, Initiator: 3", 448, 0.53125],
        ["Carry: 2, Disabler: 1, Initiator: 0", 209, 0.5311005],
        ["Carry: 2, Disabler: 3, Initiator: 0", 457, 0.5295405],
        ["Carry: 2, Disabler: 5, Initiator: 2", 87, 0.5287356],
        ["Carry: 2, Disabler: 4, Initiator: 1", 491, 0.5274949],
        ["Carry: 2, Disabler: 3, Initiator: 2", 1793, 0.524261],
        ["Carry: 4, Disabler: 4, Initiator: 2", 77, 0.5194805],
        ["Carry: 1, Disabler: 4, Initiator: 4", 52, 0.5192308],
        ["Carry: 2, Disabler: 4, Initiator: 2", 730, 0.5191781],
        ["Carry: 2, Disabler: 3, Initiator: 4", 172, 0.5174419],
        ["Carry: 3, Disabler: 4, Initiator: 2", 390, 0.5153846],
        ["Carry: 3, Disabler: 3, Initiator: 4", 144, 0.5138889],
        ["Carry: 3, Disabler: 1, Initiator: 2", 837, 0.5125448],
        ["Carry: 3, Disabler: 1, Initiator: 1", 1258, 0.5111288],
        ["Carry: 2, Disabler: 3, Initiator: 3", 887, 0.5084555],
        ["Carry: 3, Disabler: 1, Initiator: 3", 247, 0.5020243],
        ["Carry: 3, Disabler: 3, Initiator: 2", 1620, 0.5],
        ["Carry: 3, Disabler: 2, Initiator: 4", 98, 0.5],
        ["Carry: 3, Disabler: 2, Initiator: 0", 959, 0.4963504],
        ["Carry: 3, Disabler: 4, Initiator: 3", 288, 0.4930556],
        ["Carry: 3, Disabler: 2, Initiator: 3", 706, 0.4929178],
        ["Carry: 3, Disabler: 1, Initiator: 0", 673, 0.4903418],
        ["Carry: 3, Disabler: 3, Initiator: 1", 1318, 0.4893779],
        ["Carry: 3, Disabler: 4, Initiator: 1", 264, 0.4848485],
        ["Carry: 1, Disabler: 5, Initiator: 3", 66, 0.4848485],
        ["Carry: 3, Disabler: 0, Initiator: 2", 93, 0.483871],
        ["Carry: 2, Disabler: 5, Initiator: 3", 60, 0.4833333],
        ["Carry: 3, Disabler: 2, Initiator: 2", 2045, 0.4821516],
        ["Carry: 2, Disabler: 4, Initiator: 4", 139, 0.4820144],
        ["Carry: 3, Disabler: 2, Initiator: 1", 2444, 0.4819967],
        ["Carry: 4, Disabler: 2, Initiator: 0", 473, 0.4799154],
        ["Carry: 4, Disabler: 0, Initiator: 2", 110, 0.4727273],
        ["Carry: 3, Disabler: 3, Initiator: 3", 762, 0.4698163],
        ["Carry: 3, Disabler: 4, Initiator: 4", 81, 0.4691358],
        ["Carry: 3, Disabler: 3, Initiator: 0", 402, 0.4626866],
        ["Carry: 4, Disabler: 0, Initiator: 1", 294, 0.462585],
        ["Carry: 4, Disabler: 2, Initiator: 1", 1185, 0.4607595],
        ["Carry: 5, Disabler: 1, Initiator: 2", 161, 0.4596273],
        ["Carry: 3, Disabler: 0, Initiator: 0", 113, 0.4513274],
        ["Carry: 4, Disabler: 3, Initiator: 2", 438, 0.4474886],
        ["Carry: 4, Disabler: 1, Initiator: 0", 700, 0.4442857],
        ["Carry: 4, Disabler: 2, Initiator: 3", 335, 0.4417911],
        ["Carry: 4, Disabler: 1, Initiator: 1", 1122, 0.4402852],
        ["Carry: 4, Disabler: 3, Initiator: 3", 247, 0.437247],
        ["Carry: 5, Disabler: 1, Initiator: 0", 154, 0.4350649],
        ["Carry: 4, Disabler: 2, Initiator: 2", 1020, 0.4343137],
        ["Carry: 3, Disabler: 4, Initiator: 0", 72, 0.4305556],
        ["Carry: 4, Disabler: 1, Initiator: 2", 632, 0.4272152],
        ["Carry: 4, Disabler: 3, Initiator: 1", 353, 0.4220963],
        ["Carry: 4, Disabler: 3, Initiator: 0", 92, 0.4130435],
        ["Carry: 4, Disabler: 1, Initiator: 3", 136, 0.4117647],
        ["Carry: 4, Disabler: 4, Initiator: 3", 65, 0.4],
        ["Carry: 5, Disabler: 2, Initiator: 2", 158, 0.3924051],
        ["Carry: 5, Disabler: 2, Initiator: 1", 169, 0.3905326],
        ["Carry: 5, Disabler: 0, Initiator: 0", 161, 0.3850932],
        ["Carry: 4, Disabler: 0, Initiator: 0", 227, 0.3788546],
        ["Carry: 5, Disabler: 1, Initiator: 1", 288, 0.3541667],
        ["Carry: 5, Disabler: 0, Initiator: 1", 149, 0.3154362],
    ]
);

statistics.generateStatistics();