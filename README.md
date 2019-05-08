Creating a project for a training course

 Часть 1. Классы и структуры

 Задание 0. Подготовка к работе.

 Запустите программу и проверьте ее работоспособность с параметром, меньше 1. 

 С параметром больше 1 она не должна работать, это ожидаемое поведение. Мы вместе исправим 
эту ошибку позже в лабораторной работе.

 Задание 1. Рефакторинг с выделением класса

 В Data/Photos.cs картинка представлена как набор чисел с плавающей точкой.
data[x,y,c] - это значение канала c (c=0 - красный, c=1 - зеленый, c=2 - синий) пикселя
с координатой x,y. Значение находится в диапазоне от 0 до 1. 

 - Почему такое представление - плохое?
- Выделите класс Pixel с полями R,G,B и преобразуйте data к типу Pixel[,]. 
- Проведите рефакторинг, чтобы заработало. Не старайтесь сразу понять всю логику программы, 
  рефакторинг можно выполнить и без этого

 Задание 2. Защита целостности - 1

 - запустите программу с параметром, большим 1. В чем ошибка? Легко ли это понять?
- какие ограничения целостности в Pixel? Обеспечьте его выполнение. 
- исправьте ошибку из первого пункта

 Задание 3. Защита целостности - 2

 - какие ограничения целостности в Photo? Обеспечьте их выполнение
- Добавьте к классу Photo индексатор, возвращающий/устанавливающий пиксель 
  по переданным координатам.
- Подумайте, как изменился бы индексатор, если бы Pixel снова поменяли 
  с класса на структуру или наоборот.

 Задание 4. Классы и структуры

 - замените class Pixel на struct Pixel. Сделайте, чтобы заработало.
- Как изменится логика программы? Какие строки будут лишними? Почему?
- Что больше подходит в данном случае - класс или структура?


 Задание 5. Операторы

 - создайте оператор который бы позволял умножать пиксель на число и наоборот.
- насколько логично создавать оператор в данной ситуации?

 Часть 2. Наследование

 Задание 1. Реализация интерфейса

 - напишите класс GrayscaleFilter, реализующий IFilter. Он должен переводить изображение 
  в черно-белую гамму и не принимать параметров. 
- сделайте так, чтобы этот фильтр появился в окне программы

 Задание 2. Выделение метода

 - посмотрите на GrayscaleFilter и LighteningFilter. Где дублирование кода и функциональности?
- выделите метод ProcessPixel, который бы обрабатывал один пиксель. Метод Process обрабатывает все фото, 
  вызывая ProcessPixel для каждого пикселя

 Задание 3. Выделение абстрактного базового класса
- выделите дублирующуюся функциональность в абстрактный базовый класс PixelFilter
  класс реализует IFilter и Process, а ProcessPixel должен получится абстрактным методом.

 Задание 4. Большой рефакторинг.

 Это задание несколько искусственно. В проекте столь малого размера подобный рефакторинг точно 
не нужен. Однако, это задание даст возможность попрактиковаться в теме интерфейсов и 
классов, а также создаст почву для последующих улучшений.

 - создайте интерфейс IParameters - по смыслу, это интерфейс класса, который содержит настройки какого-то фильтра.
  В этом интерфейсе определите методы:
    ParameterInfo[] GetDesсription(), который будет возвращать информацию о настройках
    void Parse(double[]), который будет устанавливать поля класса в соответствие с массивом переданных величин
- создайте класс LighteningParameters с полем Coefficient, реализующий IParameters.
  Реализуйте метод Parse так, чтобы он устанавливал это поле в нулевой значение массива. 
  Аналогично с GrayscaleParameters.
- создайте класс ParametrizedFilter, который бы имел поле IParameters parameters, устанавливаемый 
  в конструкторе.
- Метод ParametrizedFilter.GetParameters() перенаправьте на parameters.GetDescription()
- сделайте абстрактный метод ParametrizedFilter.Process(Photo photo, IParameters parameters)
- В методе ParametrizedFilter.Process(Photo, double[]) вызовите parameters.Parse и затем
  ParametrizedFilter.Process(Photo, parameters)
- выведите PixelFilter из ParametrizedFilter и заставьте все заработать

 Задание 5. Дженерики

 - сделайте ParametrizedFilter дженерик-классом, принимающий дженерик-параметр, реализующий IParameters
- протащите дженерик-параметр вниз по иерархии в PixelFilter
- уберите конструкторы в иерархии наследования за счет требования new()
- создавайте новый объект параметров каждый раз при использовании
- уберите даункаст в LighteningFilter

 Часть 3. Делегаты

 Задание 1. Делегаты

 - замените в PixelFilter наследование на делегирование: этот класс должен принимать имя фильтра и функцию,
  которая принимает пиксель и параметры и возвращает пиксель
- вместо абстрактного метода ProcessPixel, вы будете вызывать эту функцию
- уберите классы LighteningFilter, GrayscaleFilter, заменив их на объекты PixelFilter с подходящей функцией

 Задание 2. Больше делегатов

 - добавьте TransformFilter, который будет выполнять преобразование изображений. Организуйте его по образцу PixelFilter
- TransformFilter должен принимать в конструкторе sizeTransform (функцию, превращающую старый размер в новый) и
  pointTransform (функция, показывающая, из какой точки старого изображения брать новую)
- создайте объекты TransformFilter для отражения изображения по горизонтали и его поворот на 90 градусов по часовой стрелке

 Задание 3. Свободное вращение

 - создайте объект TransformFilter для поворота изображения на произвольное число градусов

 Часть 4. Рефлексия типов

 Задание 1. Рефлексия

 Цель - сделать так, чтобы не приходилось реализовывать методы Parse и GetDescription в каждой новой реализации
интерфейса IParameters

 - сделайте ParameterInfo атрибутом. Примените этот атрибут к свойству Coeficient класса LighteningParameters
- уберите методы Parse и GetDescription из интерфейса IParameters, оставив его пустым
- создайте статический класс ParametersExtensions, в котором определите методы расширения Parse и GetDescription
  к интерфейсу ISettings, и заполните их следующей логикой:
  * метод GetDescription должен брать все свойства переданного объекта, для который есть атрибут ParameterInfo, 
    и возвращать соответствующий этим свойством список ParameterInfo
  * метод Parse должен составлять аналогичный список свойств, и устанавливать свойства в соответствующие значения
    переданного списка значений
