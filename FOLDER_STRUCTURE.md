# 프로젝트 폴더 구조

## 📁 전체 구조

```
3d-shop-simulator/
├── Assets/                          # Unity 에셋 폴더
│   ├── Scripts/                     # C# 스크립트
│   │   ├── Core/                   # 핵심 게임 시스템
│   │   │   ├── GameManager.cs      # 게임 관리자
│   │   │   ├── MoneySystem.cs      # 돈 시스템
│   │   │   ├── TimeManager.cs      # 시간 관리
│   │   │   └── GameConstants.cs    # 상수 정의
│   │   │
│   │   ├── Player/                 # 플레이어 관련
│   │   │   ├── PlayerController.cs # 플레��어 이동 제어
│   │   │   ├── PlayerCamera.cs     # 카메라 시스템
│   │   │   ├── PlayerPickup.cs     # 상자 집기/놓기
│   │   │   └── PlayerInput.cs      # 입력 처리
│   │   │
│   │   ├── Shop/                   # 상점 관련
│   │   │   ├── Shelf.cs            # 진열대
│   │   │   ├── Warehouse.cs        # 창고
│   │   │   ├── ShelfInventory.cs   # 진열대 재고
│   │   │   ├── ProductBox.cs       # 상품 상자
│   │   │   └── Checkout.cs         # 계산대
│   │   │
│   │   ├── Customer/               # 손님 NPC 관련
│   │   │   ├── CustomerSpawner.cs  # 손님 생성기
│   │   │   ├── CustomerAI.cs       # 손님 AI
│   │   │   ├── CustomerBehavior.cs # 손님 행동
│   │   │   └── CustomerData.cs     # 손님 데이터
│   │   │
│   │   ├── Product/                # 상품 시스템
│   │   │   ├── Product.cs          # 상품 클래스
│   │   │   ├── ProductData.cs      # 상품 데이터
│   │   │   └── ProductManager.cs   # 상품 관리
│   │   │
│   │   └── UI/                     # UI 시스템
│   │       ├── UIManager.cs        # UI 관리자
│   │       ├── MoneyUI.cs          # 돈 표시
│   │       ├── InventoryUI.cs      # 재고 표시
│   │       ├── SalesUI.cs          # 판매 기록
│   │       └── HUD.cs              # 화면 HUD
│   │
│   ├── Scenes/                      # 게임 씬
│   │   ├── MainGame.unity          # 메인 게임 씬
│   │   └── Menu.unity              # 메뉴 씬 (향후)
│   │
│   ├── Prefabs/                     # 프리팹 (재사용 가능한 오브젝트)
│   │   ├── Products/
│   │   │   ├── ProductBox.prefab   # 상품 상자
│   │   │   └── Product_A.prefab    # 상품 A 모델
│   │   │
│   │   ├── Shop/
│   │   │   ├── Shelf.prefab        # 진열대
│   │   │   ├── Checkout.prefab     # 계산대
│   │   │   └── Warehouse.prefab    # 창고
│   │   │
│   │   └── Customer/
│   │       └── Customer.prefab      # 손님 NPC
│   │
│   ├── Models/                      # 3D 모델 (.fbx, .obj)
│   │   ├── Shop/                   # 상점 구조
│   │   ├── Products/               # 상품 모델
│   │   └── Furniture/              # 가구
│   │
│   ├── Materials/                   # 머티리얼
│   │   ├── Shop/                   # 상점 머티리얼
│   │   └── UI/                     # UI 머티리얼
│   │
│   ├── Textures/                    # 텍스처 이미지
│   │   └── [...텍스처 파일들...]
│   │
│   ├── Audio/                       # 음향 파일
│   │   ├── BGM/                    # 배경음
│   │   └── SFX/                    # 효과음
│   │
│   ├── Resources/                   # 리소스 (런타임 로드)
│   │   ├── Products/               # 상품 데이터
│   │   └── UI/                     # UI 리소스
│   │
│   └── Editor/                      # 에디터 도구
│       └── EditorTools.cs          # 에디터 확장 도구
│
├── ProjectSettings/                 # Unity 프로젝트 설정
│
├── Documentation/                   # 문서
│   ├── GDD.md                      # 게임 설계 문서
│   ├── SETUP.md                    # 설정 가이드
│   └── DEVELOPMENT.md              # 개발 가이드
│
├── .gitignore                       # Git 무시 파일
├── README.md                        # 프로젝트 소개
├── MILESTONE_1.md                   # 첫 번째 마일스톤
└── CHANGELOG.md                     # 변경 이력
```

---

## 📂 각 폴더 설명

### Scripts/
- **Core**: 게임의 중심 시스템 (게임 관리, 돈, 시간)
- **Player**: 플레이어 캐릭터 제어 및 상호작용
- **Shop**: 상점 관련 시스템 (진열대, 창고, 상자)
- **Customer**: 손님 NPC와 AI
- **Product**: 상품 데이터 및 관리
- **UI**: 게임 화면 UI

### Scenes/
- 게임의 각 장면 (.unity 파일)
- MainGame: 메인 게임 플레이 씬
- Menu: 시작 메뉴 (향후 추가)

### Prefabs/
- 재사용 가능한 GameObject 템플릿
- 프리팹을 사용하면 수정 시 모든 인스턴스가 업데이트됨

### Models/
- 3D 에셋 파일 (.fbx, .obj)
- 상점 구조, 가구, 상품 모델 등

### Materials/
- 3D 오브젝트의 외형을 정의하는 머티리얼
- 색상, 질감, 반사도 등 설정

### Textures/
- 2D 이미지 파일 (.png, .jpg)
- 머티리얼에 사용되는 텍스처

### Audio/
- 음향 파일 (.wav, .mp3)
- 배경음악(BGM)과 효과음(SFX)

### Resources/
- 런타임에 동적으로 로드되는 파일
- Resources.Load()로 접근

### Editor/
- Unity 에디터 확장 도구
- 에디터에서만 작동하는 스크립트

---

## 📝 파일 명명 규칙

### C# 스크립트
```
# PascalCase (첫 글자 대문자)
PlayerController.cs
CustomerAI.cs
MoneySystem.cs
```

### Prefab, Scene
```
# PascalCase + 타입 명시 (선택사항)
Customer.prefab
Shelf.prefab
MainGame.unity
```

### 3D 모델
```
# lowercase + underscore
shop_wall.fbx
product_box.obj
```

### 이미지, 텍스처
```
# lowercase + underscore
shop_floor.png
wall_texture.jpg
```

---

## 🔄 Git 커밋 메시지

```
형식: [카테고리] 설명

카테고리:
- feat: 새로운 기능
- fix: 버그 수정
- refactor: 코드 리팩토링
- docs: 문서 작성
- style: 코드 스타일 (주석, 포맷)
- test: 테스트 추가
- chore: 설정 변경, 빌드 설정 등

예시:
[feat] Add PlayerController script
[fix] Fix customer spawn bug
[refactor] Reorganize UI manager
[docs] Update README.md
```

---

## ✅ 폴더 생성 체크리스트

- [ ] Assets/Scripts/Core
- [ ] Assets/Scripts/Player
- [ ] Assets/Scripts/Shop
- [ ] Assets/Scripts/Customer
- [ ] Assets/Scripts/Product
- [ ] Assets/Scripts/UI
- [ ] Assets/Scenes
- [ ] Assets/Prefabs/Products
- [ ] Assets/Prefabs/Shop
- [ ] Assets/Prefabs/Customer
- [ ] Assets/Models/Shop
- [ ] Assets/Models/Products
- [ ] Assets/Models/Furniture
- [ ] Assets/Materials/Shop
- [ ] Assets/Materials/UI
- [ ] Assets/Textures
- [ ] Assets/Audio/BGM
- [ ] Assets/Audio/SFX
- [ ] Assets/Resources/Products
- [ ] Assets/Resources/UI
- [ ] Assets/Editor
