![image](https://github.com/lpf0511/Software-Requirements-and-Design/assets/149307630/76ce6edb-5a16-4cda-a0b7-75727341a9f8)
用例图
用户：
用户注册和登录
预约会议室
取消或修改预约
管理员：
管理账号

类图
User：用户类，包含属性如用户名、密码。
MeetingRoom：会议室类，包含属性如会议室名称、容量。
Reservation：预约类，包含属性如预约时间、预约人等。

时序图
User对象发送登录请求给系统。
系统验证User对象的登录信息，并返回验证结果。
User对象发送预约请求给MeetingRoom对象。
MeetingRoom对象检查是否可用，并返回结果。
如果会议室可用，User对象创建Reservation对象，并发送保存请求给系统。
系统保存Reservation对象，并返回预约成功的信息给User对象。
