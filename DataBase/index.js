const mongodb = require("mongodb");
const fs = require("fs");
const { isNullOrUndefined } = require("util");
const MongoClient = require("mongodb").MongoClient;
const DATABASE_CONNECTION = "mongodb://<dbuser>:<dbpassword>@ds161483.mlab.com:61483/crawler-data".replace("<dbuser>", "duytung").replace("<dbpassword>", "duytung123");
const TABLE_NAME = {
    Products: "Products",
}
let dbContext = undefined;

const GET_DB_ASYNC = async () => {
    try {
        if (dbContext) return dbContext;
        let client = await MongoClient.connect(DATABASE_CONNECTION, { useUnifiedTopology: true });
        dbContext = client.db("crawler-data");
        return dbContext;
    } catch (err) {
        // UTILS.LOG_ERROR(err);
        throw err;
    }
}
const GET_DB_COLLECTION_ASYNC = async (collectionName) => {
    dbContext = dbContext ? dbContext : await GET_DB_ASYNC();
    return await dbContext.collection(collectionName);
}
const GET_PRODUCT = async (skip, limit = 100) => {
    const PRODUCT_COLLECTION = await GET_DB_COLLECTION_ASYNC(TABLE_NAME.Products);
    let rs = await PRODUCT_COLLECTION.aggregate([
        {
            $skip: skip
        },
        { $limit: limit },

    ]).toArray();
    return rs;
}
function change_alias(alias) {
    var str = alias;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g, " ");
    str = str.replace(/ + /g, " ");
    str = str.trim();
    return str;
}
function nameToURL(name) {
    let removeVN = change_alias(name).replace(/[^a-zA-Z ]/g, "");
    removeVN = removeVN.replace(/\s+/gi, "-");
    return removeVN;
}
function getRndInteger(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
}
function DialDiameterformat(data) {
    if (isNullOrUndefined(data) || data == "") {
        return getRndInteger(1, 10);
    }
    let rs = data.toLowerCase().replace(/mm/gi, "").trim();
    if (isNullOrUndefined(rs) || rs == "") {
        return getRndInteger(1, 10);
    }
    return parseFloat(rs);
}
function findBrandId(brandName) {
    let brandProduct = ["Patek Philippe",
        "Tag Heuer",
        "Rolex Swiss Made",
        "Omega",
        "Longines",
        "Tissot",
        "Timex",
        "Calvin Klein",
        "Movado",
        "SEIKO",
        "Citizen",
        "Orient",
        "Casio",
        "Fossil",
        "Michael Kors",
        "Ogival",
        "OP: Olympia Star, Olym Pianus",
        "DW (Daniel Wellington)",
        "Anne Klein",
        "Guess",
        "Breitling",
        "Piaget",
        "Breguet",
        "Zenith",
        "Vacheron Constantin",
        "Audemars Piguet",
        "Hublot",
        "Jaguar",
        "Mido",
        "Candino",
        "Rado Switzerland",
        "Swatch",
        "Century",
        "Certina",
        "Roamer",
        "Perrelet",
        "Chronoswiss",
        "Frederique Constant (FC)",
        "IWC",
        "BulovaBulova",
        "DavenaDavena",
        "Royal CrownRoyal Crown",
        "SunriseSunrise",
        "EarnshawEarnshaw",
        "AlpinaAlpina",
        "TissotTissot",
        "SeikoSeiko",
        "AkribosAkribos",
        "Anne KleinAnne Klein",
        "AolixAolix",
        "ADEE KAYEADEE KAYE",
        "Armani ExchangeArmani Exchange",
        "ArbutusArbutus",
        "B SwissB Swiss",
        "Badgley MischkaBadgley Mischka",
        "Armand NicoletArmand Nicolet",
        "Brooklyn Watch CoBrooklyn Watch Co",
        "BombergBomberg",
        "BallBall",
        "BalmainBalmain",
        "BentleyBentley",
        "BugriBugri",
        "BurgiBurgi",
        "Bruno MagliBruno Magli",
        "BurberryBurberry",
        "Caravelle New YorkCaravelle New York",
        "CasioCasio",
        "CarnivalCarnival",
        "CaravelleCaravelle",
        "Calvin KleinCalvin Klein",
        "CCCPCCCP",
        "CharmexCharmex",
        "Christian Van SantChristian Van Sant",
        "CharriolCharriol",
        "Claude BernardClaude Bernard",
        "CoachCoach",
        "CertinaCertina",
        "Daniel WellingtonDaniel Wellington",
        "CorumCorum",
        "CitizenCitizen",
        "DKNYDKNY",
        "edoxedox",
        "DiorDior",
        "Emporio ArmaniEmporio Armani",
        "FerrariFerrari",
        "EternaEterna",
        "FendiFendi",
        "Elini BarokasElini Barokas",
        "Ferre MilanoFerre Milano",
        "Frederique ConstantFrederique Constant",
        "FUJIFUJI",
        "FossilFossil",
        "FurlaFurla",
        "GCGC",
        "GrovanaGrovana",
        "GemaxGemax",
        "GosttaGostta",
        "GucciGucci",
        "GevrilGevril",
        "Guess CollectionGuess Collection",
        "GuessGuess",
        "Guess WaferGuess Wafer",
        "GV2GV2",
        "HamiltonHamilton",
        "HermesHermes",
        "HubolerHuboler",
        "HublotHublot",
        "GV2 VittoriaGV2 Vittoria",
        "HanboroHanboro",
        "InvictaInvicta",
        "Jacques LemansJacques Lemans",
        "JBWJBW",
        "Juicy CoutureJuicy Couture",
        "LonginesLongines",
        "LUCIEN PICCARDLUCIEN PICCARD",
        "Just CavalliJust Cavalli",
        "Kate SpadeKate Spade",
        "Marc JacobsMarc Jacobs",
        "MATHEY-TISSOTMATHEY-TISSOT",
        "MASERATIMASERATI",
        "Mark & JonesMark & Jones",
        "Maurice LacroixMaurice Lacroix",
        "Mazzucato EgoMazzucato Ego",
        "MONTBLANCMONTBLANC",
        "MelissaMelissa",
        "MidoMido",
        "MovadoMovado",
        "Michael KorsMichael Kors",
        "OmegaOmega",
        "OgivalOgival",
        "OnissOniss",
        "Olym PianusOlym Pianus",
        "Olympia StarOlympia Star",
        "OrisOris",
        "PolicePolice",
        "PeugeotPeugeot",
        "PerreletPerrelet",
        "OrientOrient",
        "Raymond WeilRaymond Weil",
        "Reef TigerReef Tiger",
        "RadoRado",
        "Revue ThommenRevue Thommen",
        "PulsarPulsar",
        "Roberto CavalliRoberto Cavalli",
        "S CoifmanS Coifman",
        "RotaryRotary",
        "Salvatore FerragamoSalvatore Ferragamo",
        "SevenFridaySevenFriday",
        "SkagenSkagen",
        "Serene Marceau DiamondSerene Marceau Diamond",
        "SeahSeah",
        "StuhrlingStuhrling",
        "StarkeStarke",
        "SwarovskiSwarovski",
        "Speake MarinSpeake Marin",
        "TED BAKERTED BAKER",
        "Tory BurchTory Burch",
        "TechnomarineTechnomarine",
        "Tommy BahamaTommy Bahama",
        "Vince CamutoVince Camuto",
        "VictorinoxVictorinox",
        "WengerWenger",
        "versusversus",
        "VersaceVersace",
        "WittnauerWittnauer",
        "X-cerX-cer",
        "Bulova",
        "Davena",
        "Royal Crown",
        "Sunrise",
        "Earnshaw",
        "Alpina",
        "Akribos",
        "Aolix",
        "ADEE KAYE",
        "thương hiệu orient",
        "Armani Exchange",
        "Arbutus",
        "B Swiss",
        "Badgley Mischka",
        "Armand Nicolet",
        "Brooklyn Watch Co",
        "Bomberg",
        "Ball",
        "Balmain",
        "Bentley",
        "Bugri",
        "Burgi",
        "Bruno Magli",
        "Burberry",
        "thương hiệu fouetté (phiên bản giới hạn 99 chiếc trên toàn thế giới)",
        "Caravelle New York",
        "Carnival",
        "Caravelle",
        "CCCP",
        "Charmex",
        "Christian Van Sant",
        "Charriol",
        "Claude Bernard",
        "Coach",
        "Daniel Wellington",
        "Corum",
        "DKNY",
        "edox",
        "Dior",
        "Emporio Armani",
        "Ferrari",
        "Eterna",
        "Fendi",
        "Elini Barokas",
        "Ferre Milano",
        "Frederique Constant",
        "FUJI",
        "Furla",
        "GC",
        "Grovana",
        "Gemax",
        "Gostta",
        "Gucci",
        "Gevril",
        "Guess Collection",
        "Guess Wafer",
        "GV2",
        "Hamilton",
        "Hermes",
        "Huboler",
        "GV2 Vittoria",
        "Hanboro",
        "Invicta",
        "Jacques Lemans",
        "JBW",
        "Juicy Couture",
        "LUCIEN PICCARD",
        "Just Cavalli",
        "Kate Spade",
        "Marc Jacobs",
        "MATHEYTISSOT",
        "MASERATI",
        "Mark & Jones",
        "Maurice Lacroix",
        "Mazzucato Ego",
        "MONTBLANC",
        "Melissa",
        "Oniss",
        "Olym Pianus",
        "Olympia Star",
        "Oris",
        "Police",
        "Peugeot",
        "Raymond Weil",
        "Reef Tiger",
        "Rado",
        "Revue Thommen",
        "Pulsar",
        "Roberto Cavalli",
        "S Coifman",
        "Rotary",
        "Salvatore Ferragamo",
        "SevenFriday",
        "Skagen",
        "Serene Marceau Diamond",
        "Seah",
        "Stuhrling",
        "Starke",
        "Swarovski",
        "Speake Marin",
        "TED BAKER",
        "Tory Burch",
        "Technomarine",
        "Tommy Bahama",
        "Vince Camuto",
        "Victorinox",
        "Wenger",
        "versus",
        "Versace",
        "Wittnauer",
        "Xcer",
        "Doxa",
        "Saga",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findMachineId(brandName) {
    let brandProduct = ["Pin (Quartz)",
        "",
        "Cơ (Automatic)",
        "Năng Lượng Ánh Sáng",
        "Năng Lượng Ánh Sáng, Pin (Quartz)",
        "Kinetic (Vừa Pin – Vừa Tự Động)",
        "Automatic (Tự Động)",
        "Quartz (Pin)",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findBandId(brandName) {
    let brandProduct = ["Thép không rỉ (Inox)",
        "Titanium",
        "Xi",
        "Da",
        "Da vân nguyên bản",
        "Dây da giả da cá sấu",
        "Dây da giả vân",
        "Dây da giả da",
        "Nato",
        "Vải",
        "Nhựa",
        "Cao su",
        "Đá",
        "gốm",
        "ceramic",
        "OYSTER",
        "JUBILEE",
        "PRESIDENT",
        "MILANESE",
        "BEADS OF RICE",
        "ROYAL OAK",
        "BONKLIP",
        "Twist-O-Flex",
        "H-link",
        "Shark Mesh",
        "Engineer",
        "Ladder",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findStrapId(brandName) {
    let brandProduct = ["Dây kim loại",
        "Dây da",
        "Dây da, Dây kim loại",
        "Dây nhựa / Cao su",
        "Dây đá cerramic",
        "Thép Không Gỉ",
        "",
        "Dây đá cerramic, Thép Không Gỉ",
        "Dây Nhựa, Dây nhựa / Cao su",
        "Dây Nhựa",
        "Dây vải",
        "Dây kim loại, Thép Không Gỉ",
        "Dây TiTanium",
        "Dây kim loại, Dây Nhựa, Dây nhựa / Cao su",
        "Dây da, Dây vải",
        "Dây nhựa / Cao su, Navy Silicone",
        "Dây đá cerramic, Dây kim loại",
        "Dây da, Dây nhựa / Cao su",
        "Dây da, Dây kim loại, Dây nhựa / Cao su",
        "Navy Silicone",
        "Dây đá / Khoáng, Dây kim loại",
        "Dây Nhựa, Thép Không Gỉ",
        "Dây da, Thép Không Gỉ",
        "Dây Nhựa, Dây nhựa / Cao su, Navy Silicone",
        "Thép không rỉ (Inox)",
        "Titanium",
        "Xi",
        "Da",
        "Da vân nguyên bản",
        "Dây da giả da cá sấu",
        "Dây da giả vân",
        "Dây da giả da",
        "Nato",
        "Vải",
        "Nhựa",
        "Cao su",
        "Đá",
        "gốm",
        "ceramic",
        "OYSTER",
        "JUBILEE",
        "PRESIDENT",
        "MILANESE",
        "BEADS OF RICE",
        "ROYAL OAK",
        "BONKLIP",
        "Twist-O-Flex",
        "H-link",
        "Shark Mesh",
        "Engineer",
        "Ladder,"];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findColorClockFacesId(brandName) {
    let brandProduct = ["Kính cứng",
        "Kính Sapphire",
        "",
        "Kính đặc biệt",
        "Kính Hardlex",
        "Kính đặc biệt, Kính Hardlex",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findMadeInId(brandName) {
    let brandProduct = ["Mỹ",
        "Hong Kong",
        "Thụy Sĩ",
        "Anh",
        "Nhật Bản",
        "xuất xứ nhật bản",
        "Italia",
        "Pháp",
        "Đức",
        "xuất xứ hồng kông",
        "",
        "Nga",
        "Bỉ",
        "Đan Mạch",
        "Áo",
        "Hàn Quốc",
        "Thụy Sỹ",
        "Thụy Điển",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findStyleId(brandName) {
    let brandProduct = ["Lịch lãm",
        "Trẻ trung",
        "Quý phái",
        "Năng động",
        "Sang Trọng, Thời Trang",
        "Cá Tính, Sang Trọng, Thời Trang",
        "Cá Tính",
        "Classic ( Cổ điển ), Sang Trọng",
        "Cá Tính, Sang Trọng",
        "",
        "Classic ( Cổ điển ), Sang Trọng, Thời Trang",
        "Sang Trọng",
        "Classic ( Cổ điển )",
        "Thể Thao",
        "Cá Tính, Thể Thao",
        "Beige, Classic ( Cổ điển ), Sang Trọng",
        "Thời Trang",
        "Thể Thao, Thời Trang",
        "Sang Trọng, Thể Thao",
        "Sang Trọng, Thể Thao, Thời Trang",
        "Classic ( Cổ điển ), Thể Thao",
        "Classic ( Cổ điển ), Thời Trang",
        "Cá Tính, Classic ( Cổ điển ), Sang Trọng",
        "Cá Tính, Thể Thao, Thời Trang",
        "Cá Tính, Classic ( Cổ điển )",
        "Cá Tính, Sang Trọng, Thể Thao",
        "Cá Tính, Thời Trang",
        "Parker",
        "Cá Tính, Sang Trọng, Thể Thao, Thời Trang",
        "Parker, Sang Trọng",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findWaterproofId(brandName) {
    let brandProduct = ["30m/3 ATM/3 Bar",
        "50m/5 ATM/5 Bar",
        "100m/10 ATM/10 Bar",
        "200m/20 ATM/20 Bar",
        "770m/77 ATM/77 Bar",
        "1000m/100 ATM/100 Bar",
        "2000m/200 ATM/200 Bar",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function findCategoryId(brandName) {
    let brandProduct = ["Đồng hồ nữ",
        "Đồng hồ nam",
        "Đồng hồ cặp",
        "Đồng hồ trẻ em",
        "Chưa phân loại",];
    let found = false;
    let indexFound = -1;
    for (let i = 0; i < brandProduct.length; i++) {
        const name = brandProduct[i];
        if (brandName && brandName.toLowerCase() == name.toLowerCase()) {
            found = true;
            indexFound = i + 1;
            break;
        }
    }
    if (found) {
        return indexFound;
    }
    return getRndInteger(1, brandProduct.length);
}
function preparePrice(price){
    if(isNullOrUndefined(price) || price == ""){
        return getRndInteger(1500000,100000000);
    }
    if(price.includes("₫")){
        // price = (price.split("₫")[0]).toLowerCase().trim().replace(".","").replace(",","");
        price = (price.split("₫")[0]).toLowerCase().trim().replace(/\./gi,"").replace(/,/gi,"");
    }
    // price = price.toLowerCase().trim().replace(".","").replace(",","");
    price = price.toLowerCase().trim().replace(/\./gi,"").replace(/,/gi,"");
    return parseFloat(price);
}
let main = async () => {
    // let startTotal = new Date;
    // let allProduct = [];
    // let count = 1;
    // while (count > 0) {
    //     let start = new Date;
    //     let products = await GET_PRODUCT(allProduct.length);
    //     count = products.length;
    //     allProduct = allProduct.concat(products);
    //     console.log(`Thời gian lấy 100 sản phẩm : ${((new Date) - start) / 1000} s . Tổng sản phẩm : ${allProduct.length}. Thời gian chạy nãy giờ : ${((new Date) - startTotal) / 1000} s`)
    // }
    // fs.writeFileSync("./allProduct.json", JSON.stringify(allProduct))
    // console.log("DONE")
    let products = await fs.readFileSync('./allProduct.json');
    products = JSON.parse(products);


    // products = products.slice(0, 5);
    // console.log(products[0])
    // let allInsertData = [];
    // for (let i = 0; i < products.length; i++) {
    //     let product = products[i];
    //     let abc = `INSERT INTO Products(Name, Sku, Url, Price, Diameter, ThicknessOfClass, BrandProductId, MachineId, BandId, StrapId, ColorClockFaceId, MadeInId, StyleId, WaterproofId, CategoryId, CreateBy , DescriptionFull) VALUES(N'${product.name.replace(/'/gi,"")}', N'${product.code.replace(/'/gi,"")}', '${nameToURL(product.name)}', ${preparePrice(product.price)}, N'${product.property_Detail.DialDiameter}',${DialDiameterformat(product.property_Detail.Thickness)},${findBrandId(product.property_Detail.Brand)},${findMachineId(product.property_Detail.TypeOfMachine)},${findBandId(product.property_Detail.Bark)}, ${findStrapId(product.property_Detail.WireMaterial)}, ${findColorClockFacesId(product.property_Detail.FaceColor)},${findMadeInId(product.property_Detail.From)},${findStyleId(product.property_Detail.Style)},${findWaterproofId(product.property_Detail.WaterResistant)},${findCategoryId(product.property_Detail.category)},N'Hệ thống' , N'${product.description.replace(/'/gi,"")}');`;
    //     // console.log(abc)
    //     allInsertData.push(abc);
    //     // console.log(`${preparePrice(product.price)} == ${product.price}`)
    // };
    // fs.writeFileSync("./queryInsert.txt",allInsertData.join("\n"));
    let allProductStatus = [];
    for (let i = 1; i < 4707; i++) {
        // let abc = `INSERT INTO Product_ProductStatus(ProductId,ProductStatusId) VALUES(${getRndInteger(1,4707)},${getRndInteger(2,4)});`;
        let abc = `INSERT INTO Product_ProductStatus(ProductId,ProductStatusId) VALUES(${i},${getRndInteger(1,9)});`;
        allProductStatus.push(abc);
    }
    fs.writeFileSync("./productStatus.txt",allProductStatus.join("\n"));

}
main();